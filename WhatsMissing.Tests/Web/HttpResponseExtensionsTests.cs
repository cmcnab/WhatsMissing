namespace WhatsMissing.Tests.Web
{
    using System.IO;
    using System.Threading.Tasks;
    using Moq;
    using WhatsMissing.Web;
    using Xunit;

    public class HttpResponseExtensionsTests
    {
        [Fact]
        public void Deserialize_StreamToInt_WorksCorrectly()
        {
            // Arrange
            var response = new Mock<IHttpResponse>();
            response.Setup(r => r.GetResponseStream()).Returns(MemoryStreams.CreateWith("7856"));

            // Act
            var result = response.Object.Deserialize(s => int.Parse(s.ReadToEnd()));

            // Assert
            Assert.Equal(7856, result);
        }

        [Fact]
        public void DeserializeAsync_StreamToInt_WorksCorrectly()
        {
            // Arrange
            var response = new Mock<IHttpResponse>();
            response.Setup(r => r.GetResponseStream()).Returns(MemoryStreams.CreateWith("7856"));

            // Act
            var result = response.Object.DeserializeAsync(s => Task.FromResult(int.Parse(s.ReadToEnd()))).Result;

            // Assert
            Assert.Equal(7856, result);
        }
    }
}
