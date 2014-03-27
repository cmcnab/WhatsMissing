namespace WhatsMissing.Tests.Xml
{
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

        private static void WritePerson(XmlWriter writer, Person person)
        {
            writer.WriteElementString("LastName", person.LastName);
            writer.WriteElementString("FirstName", person.FirstName);
            writer.WriteObject("Address", person.Address, WriteAddress);
        }

        private static void WriteAddress(XmlWriter writer, Address address)
        {
            writer.WriteElementString("City", address.City);
            writer.WriteElementString("State", address.State);
        }

        private static string ResetAndReadToEnd(MemoryStream stream)
        {
            stream.Position = 0;
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
