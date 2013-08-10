namespace WhatsMissing.Tests
{
    using System.Collections.Generic;
    using Moq;
    using Xunit;

    public class ListExtensionsTests
    {
        [Fact]
        public static void ShuffleArray()
        {
            // Arrange
            var rng = new Mock<IRandomGenerator>();
            var items = new int[] { 1, 2, 3, 4 };

            rng.Setup(r => r.Next(It.IsAny<int>())).Returns(0);

            // Act
            var shuffled = items.Shuffle(rng.Object);

            // Assert
            //  An RNG that always returns zero means the algorithm will shuffle each position
            //  starting with the last with the first position.
            var expected = new int[] { 2, 3, 4, 1 };
            Assert.Equal(expected, shuffled);
        }

        [Fact]
        public static void ShuffleList()
        {
            // Arrange
            var rng = new Mock<IRandomGenerator>();
            var items = new List<int>() { 1, 2, 3, 4 };

            rng.Setup(r => r.Next(It.IsAny<int>())).Returns(0);

            // Act
            var shuffled = items.Shuffle(rng.Object);

            // Assert
            //  An RNG that always returns zero means the algorithm will shuffle each position
            //  starting with the last with the first position.
            var expected = new List<int>() { 2, 3, 4, 1 };
            Assert.Equal(expected, shuffled);
        }
    }
}
