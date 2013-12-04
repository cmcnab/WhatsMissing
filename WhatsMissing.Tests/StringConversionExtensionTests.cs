namespace WhatsMissing.Tests
{
    using Xunit;

    public class StringConversionExtensionTests
    {
        #region EmptyIfNull

        [Fact]
        public void EmptyIfNull_Null_ReturnsEmpty()
        {
            // Arrange
            string input = null;

            // Act
            var output = input.EmptyIfNull();

            // Assert
            Assert.Equal(string.Empty, output);
        }

        [Fact]
        public void EmptyIfNull_NotNull_ReturnsValue()
        {
            // Arrange
            string input = "123";

            // Act
            var output = input.EmptyIfNull();

            // Assert
            Assert.Equal(input, output);
        }

        #endregion

        #region AsBool

        [Fact]
        public void AsBool_Null_ReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            var output = input.AsBool();

            // Assert
            Assert.True(output == null);
        }

        [Fact]
        public void AsBool_NotABool_ReturnsNull()
        {
            // Arrange
            string input = "fooey";

            // Act
            var output = input.AsBool();

            // Assert
            Assert.True(output == null);
        }

        [Fact]
        public void AsBool_IsABool_ReturnsValue()
        {
            // Arrange
            string input = "true";

            // Act
            var output = input.AsBool();

            // Assert
            Assert.Equal(true, output.Value);
        }

        [Fact]
        public void AsBool_IsABoolMixedCase_ReturnsValue()
        {
            // Arrange
            string input = "True";

            // Act
            var output = input.AsBool();

            // Assert
            Assert.Equal(true, output.Value);
        }

        #endregion

        #region AsBoolOrDefault

        [Fact]
        public void AsBoolOrDefault_Null_ReturnsDefault()
        {
            // Arrange
            string input = null;

            // Act
            var output = input.AsBoolOrDefault();

            // Assert
            Assert.Equal(default(bool), output);
        }

        [Fact]
        public void AsBoolOrDefault_NotABool_ReturnsDefault()
        {
            // Arrange
            string input = "fooey";

            // Act
            var output = input.AsBoolOrDefault();

            // Assert
            Assert.Equal(default(bool), output);
        }

        [Fact]
        public void AsBoolOrDefault_NotABoolWithOverride_ReturnsOverride()
        {
            // Arrange
            string input = "fooey";

            // Act
            var output = input.AsBoolOrDefault(true);

            // Assert
            Assert.Equal(true, output);
        }

        [Fact]
        public void AsBoolOrDefault_IsABool_ReturnsValue()
        {
            // Arrange
            string input = "true";

            // Act
            var output = input.AsBoolOrDefault();

            // Assert
            Assert.Equal(true, output);
        }

        [Fact]
        public void AsBoolOrDefault_IsABoolMixedCase_ReturnsValue()
        {
            // Arrange
            string input = "True";

            // Act
            var output = input.AsBoolOrDefault();

            // Assert
            Assert.Equal(true, output);
        }

        #endregion
    }
}
