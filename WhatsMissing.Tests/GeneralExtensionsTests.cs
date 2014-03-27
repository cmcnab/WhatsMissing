namespace WhatsMissing.Tests
{
    using System;
    using Xunit;

    public class GeneralExtensionsTests
    {
        [Fact]
        public void ToStringNotNullObjectReturnsString()
        {
            // Arrange
            Uri uri = new Uri("http://localhost");

            // Act
            var str = uri.IfNotNull(u => u.ToString());

            // Assert
            Assert.Equal(uri.ToString(), str);
        }

        [Fact]
        public void ToStringNullObjectReturnsNull()
        {
            // Arrange
            Uri uri = null;

            // Act
            var str = uri.IfNotNull(u => u.ToString());

            // Assert
            Assert.Null(str);
        }

        [Fact]
        public void ChainedIfNotNull_FirstNull_ExpressionIsDefault()
        {
            // Arrange
            Uri uri = null;

            // Act
            var len = uri.IfNotNull(u => u.ToString()).IfNotNull(s => s.Length);

            // Assert
            Assert.Equal(default(int), len);
        }

        [Fact]
        public void IfNotNullCanSpecifyAlternativeDefaultValue()
        {
            // Arrange
            Uri uri = null;

            // Act
            var defStr = "foo";
            var str = uri.IfNotNull(u => u.ToString(), defStr);

            // Assert
            Assert.Equal(defStr, str);
        }

        [Fact]
        public void NullableIntIfHasValue_HasValue_ReturnsValue()
        {
            // Arrange
            int? input = 42;

            // Act
            var result = input.IfHasValue(n => n / 2);

            // Assert
            Assert.Equal(21, result);
        }

        [Fact]
        public void NullableIntIfHasValue_NoValue_ReturnsDefault()
        {
            // Arrange
            int? input = null;

            // Act
            var result = input.IfHasValue(n => n / 12);

            // Assert
            Assert.Equal(default(int), result);
        }

        [Fact]
        public void NullableIntIfHasValueSpecifyDefault_NoValue_ReturnsSepcifiedDefault()
        {
            // Arrange
            int? input = null;

            // Act
            var result = input.IfHasValue(n => n / 12, 100);

            // Assert
            Assert.Equal(100, result);
        }
    }
}
