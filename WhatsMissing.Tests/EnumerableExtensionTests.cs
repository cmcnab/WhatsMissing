namespace WhatsMissing.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    public class EnumerableExtensionTests
    {
        [Fact]
        public void Pairwise_SomeElements_ReturnsPairs()
        {
            // Arrange
            var seq = new[] { 1, 2, 3, 4 };

            // Act
            var pairs = seq.Pairwise().ToList();

            // Assert
            var expected = new[]
            {
                Tuple.Create(1, 2),
                Tuple.Create(2, 3),
                Tuple.Create(3, 4)
            };
            Assert.Equal(expected, pairs);
        }

        [Fact]
        public void Pairwise_NoElements_ReturnsNoPairs()
        {
            // Arrange
            var seq = new int[] { };

            // Act
            var pairs = seq.Pairwise().ToList();

            // Assert
            var expected = new Tuple<int, int>[] { };
            Assert.Equal(expected, pairs);
        }
    }
}
