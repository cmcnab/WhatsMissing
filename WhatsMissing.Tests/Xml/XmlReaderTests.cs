namespace WhatsMissing.Tests.Xml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using WhatsMissing.Xml;
    using Xunit;

    public class XmlReaderTests
    {
        [Fact]
        public void ReadObjectSwitchStyle_PersonAndAddress_SerializesCorrectly()
        {
            // Arrange
            var input = "<Person><LastName>Doe</LastName><FirstName>John</FirstName><Address><City>Madison</City><State>WI</State></Address></Person>";

            using (var stream = new MemoryStream())
            {
                WriteStringAndReset(stream, input);

                // Act
                var reader = XmlReader.Create(stream);
                reader.MoveToNextElement();
                var person = reader.ReadObject<Person>(ReadPerson);

                // Assert
                Assert.Equal("Doe", person.LastName);
                Assert.Equal("John", person.FirstName);
                Assert.Equal("Madison", person.Address.City);
                Assert.Equal("WI", person.Address.State);
            }
        }

        [Fact]
        public void ReadObjectHandlerStyle_PersonAndAddress_SerializesCorrectly()
        {
            // Arrange
            var input = "<Person><LastName>Doe</LastName><FirstName>John</FirstName><Address><City>Madison</City><State>WI</State></Address></Person>";

            using (var stream = new MemoryStream())
            {
                WriteStringAndReset(stream, input);

                // Act
                var reader = XmlReader.Create(stream);
                reader.MoveToNextElement();
                var person = reader.ReadObject<Person>(PersonReader);

                // Assert
                Assert.Equal("Doe", person.LastName);
                Assert.Equal("John", person.FirstName);
                Assert.Equal("Madison", person.Address.City);
                Assert.Equal("WI", person.Address.State);
            }
        }

        [Fact]
        public void ReadObjectList_AddressBook_SerializesCorrectly()
        {
            // Arrange
            var input = "<AddressBook><Name>Book 1</Name><Addresses><Address><City>Madison</City><State>WI</State></Address><Address><City>Rochester</City><State>NY</State></Address></Addresses></AddressBook>";

            using (var stream = new MemoryStream())
            {
                WriteStringAndReset(stream, input);

                // Act
                var reader = XmlReader.Create(stream);
                reader.MoveToNextElement();
                var addressBook = reader.ReadObject<AddressBook>(AddressBookReader);

                // Assert
                Assert.Equal("Book 1", addressBook.Name);
                Assert.Equal(2, addressBook.Addresses.Count);
                Assert.Equal("Madison", addressBook.Addresses[0].City);
                Assert.Equal("WI", addressBook.Addresses[0].State);
                Assert.Equal("Rochester", addressBook.Addresses[1].City);
                Assert.Equal("NY", addressBook.Addresses[1].State);
            }
        }

        private static void PersonReader(XmlReader reader, IDictionary<string, Action<Person>> elementHandlers)
        {
            elementHandlers["LastName"] = p => p.LastName = reader.ReadElementText();
            elementHandlers["FirstName"] = p => p.FirstName = reader.ReadElementText();
            elementHandlers["Address"] = p => p.Address = reader.ReadObject<Address>(AddressReader);
        }

        private static void AddressBookReader(XmlReader reader, IDictionary<string, Action<AddressBook>> elementHandlers)
        {
            elementHandlers["Name"] = ab => ab.Name = reader.ReadElementText();
            elementHandlers["Addresses"] = ab => ab.Addresses = reader.ReadObjectList<Address>("Address", AddressReader);
        }

        private static void AddressReader(XmlReader reader, IDictionary<string, Action<Address>> elementHandlers)
        {
            elementHandlers["City"] = a => a.City = reader.ReadElementText();
            elementHandlers["State"] = a => a.State = reader.ReadElementText();
        }

        private static void ReadPerson(XmlReader reader, Person person)
        {
            switch (reader.LocalName)
            {
                case "LastName":
                    person.LastName = reader.ReadElementText();
                    break;

                case "FirstName":
                    person.FirstName = reader.ReadElementText();
                    break;

                case "Address":
                    person.Address = reader.ReadObject<Address>(ReadAddress);
                    break;
            }
        }

        private static void ReadAddress(XmlReader reader, Address address)
        {
            switch (reader.LocalName)
            {
                case "City":
                    address.City = reader.ReadElementText();
                    break;

                case "State":
                    address.State = reader.ReadElementText();
                    break;
            }
        }

        private static void WriteStringAndReset(MemoryStream stream, string value)
        {
            var writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
        }
    }
}
