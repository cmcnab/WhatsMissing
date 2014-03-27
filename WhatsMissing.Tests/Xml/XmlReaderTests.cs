namespace WhatsMissing.Tests.Xml
{
    using System.IO;
    using System.Xml;
    using WhatsMissing.Xml;
    using Xunit;

    public class XmlReaderTests
    {
        [Fact]
        public void ReadObject_PersonAndAddress_SerializesCorrectly()
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
