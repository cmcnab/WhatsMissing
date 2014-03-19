namespace WhatsMissing.Tests.Web
{
    using System.IO;
    using System.Threading.Tasks;
    using Moq;
    using WhatsMissing.Web;
    using Xunit;

    public class HttpRequestExtensionsTests
    {
        [Fact]
        public void HttpGetAsync_SetsMethodToGet()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();

            // Act
            request.Object.HttpGetAsync().Wait();

            // Assert
            request.VerifySet(r => r.Method = "GET", Times.Once());
        }

        [Fact]
        public void HttpGetAsync_ReturnsResponse()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();
            var reqResponse = Mock.Of<IHttpResponse>();
            request.Setup(r => r.GetResponseAsync()).Returns(Task.FromResult(reqResponse));

            // Act
            var result = request.Object.HttpGetAsync().Result;

            // Assert
            Assert.Equal(reqResponse, result);
        }

        [Fact]
        public void HttpGetAsync_DeserializeInt_ReturnsCorrectly()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();
            var response = new Mock<IHttpResponse>();
            response.Setup(r => r.GetResponseStream()).Returns(MemoryStreams.CreateWith("7856"));
            request.Setup(r => r.GetResponseAsync()).Returns(Task.FromResult(response.Object));

            // Act
            var result = request.Object.HttpGetAsync(s => int.Parse(s.ReadToEnd())).Result;

            // Assert
            Assert.Equal(7856, result);
        }

        [Fact]
        public void HttpPostAsync_SetsMethodToPost()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();

            // Act
            request.Object.HttpPostAsync().Wait();

            // Assert
            request.VerifySet(r => r.Method = "POST", Times.Once());
        }

        [Fact]
        public void HttpPostAsync_WithContent_SetsContentType()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();

            // Act
            request.Object.HttpPostAsync("application/json", s => { }).Wait();

            // Assert
            request.VerifySet(r => r.ContentType = "application/json", Times.Once());
        }

        [Fact]
        public void HttpPostAsync_WithContent_RequestStreamIsPassed()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();
            var requestStream = new MemoryStream();
            request.Setup(r => r.GetRequestStreamAsync()).Returns(Task.FromResult<Stream>(requestStream));

            // Act
            Stream capturedStream = null;
            request.Object.HttpPostAsync("application/json", s => capturedStream = s).Wait();

            // Assert
            Assert.Equal(requestStream, capturedStream);
        }

        [Fact]
        public void HttpPostAsync_ResponseHasContent_ContentDeserialized()
        {
            // Arrange
            var request = new Mock<IHttpRequest>();
            var response = new Mock<IHttpResponse>();
            response.Setup(r => r.GetResponseStream()).Returns(MemoryStreams.CreateWith("7856"));
            request.Setup(r => r.GetResponseAsync()).Returns(Task.FromResult(response.Object));

            // Act
            var result = request.Object.HttpPostAsync("application/json", null, s => int.Parse(s.ReadToEnd())).Result;

            // Assert
            Assert.Equal(7856, result);
        }
    }
}
