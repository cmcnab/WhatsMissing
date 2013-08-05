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
    }
}
