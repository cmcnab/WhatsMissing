namespace WhatsMissing.Tests.Xml
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using WhatsMissing.Xml;
    using Xunit;

    public class XmlWriterTests
    {
        [Fact]
        public void WriteObject_PersonAndAddress_SerializesCorrectly()
        {
            // Arrange
            var person = new Person()
            {
                LastName = "Doe",
                FirstName = "John",
                Address = new Address()
                {
                    City = "Madison",
                    State = "WI"
                }
            };

            // Act
            using (var stream = new MemoryStream())
            {
                var writer = XmlWriter.Create(stream, new XmlWriterSettings() { OmitXmlDeclaration = true });
                writer.WriteObject("Person", person, WritePerson);

                writer.Flush();
                var result = ResetAndReadToEnd(stream);

                // Assert
                var expected = "<Person><LastName>Doe</LastName><FirstName>John</FirstName><Address><City>Madison</City><State>WI</State></Address></Person>";
                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void WriteObjectList_AddressBook_SerializesCorrectly()
        {
            // Arrange
            var addressBook = new AddressBook()
            {
                Name = "Book 1",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                        City = "Madison",
                        State = "WI"
                    },
                    new Address()
                    {
                        City = "Rochester",
                        State = "NY"
                    }
                }
            };

            // Act
            using (var stream = new MemoryStream())
            {
                var writer = XmlWriter.Create(stream, new XmlWriterSettings() { OmitXmlDeclaration = true });
                writer.WriteObject("AddressBook", addressBook, WriteAddressBook);

                writer.Flush();
                var result = ResetAndReadToEnd(stream);

                // Assert
                var expected = "<AddressBook><Name>Book 1</Name><Addresses><Address><City>Madison</City><State>WI</State></Address><Address><City>Rochester</City><State>NY</State></Address></Addresses></AddressBook>";
                Assert.Equal(expected, result);
            }
        }

        private static void WritePerson(XmlWriter writer, Person person)
        {
            writer.WriteElementText("LastName", person.LastName);
            writer.WriteElementText("FirstName", person.FirstName);
            writer.WriteObject("Address", person.Address, WriteAddress);
        }

        private static void WriteAddressBook(XmlWriter writer, AddressBook addressBook)
        {
            writer.WriteElementText("Name", addressBook.Name);
            writer.WriteObjectList("Addresses", "Address", addressBook.Addresses, WriteAddress);
        }

        private static void WriteAddress(XmlWriter writer, Address address)
        {
            writer.WriteElementText("City", address.City);
            writer.WriteElementText("State", address.State);
        }

        private static string ResetAndReadToEnd(MemoryStream stream)
        {
            stream.Position = 0;
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
