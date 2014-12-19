namespace WhatsMissing.Tests
{
    using System;
    using System.Collections.Generic;
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

        [Fact]
        public void Separator_NullSequence_Throws()
        {
            // Arrange
            IEnumerable<int> seq = null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => seq.Separator(0).ToList());
        }

        [Fact]
        public void Separator_NoElements_ReturnsEmpty()
        {
            // Arrange
            var seq = new int[] { };

            // Act
            var results = seq.Separator(0).ToList();

            // Assert
            Assert.Equal(0, results.Count);
        }

        [Fact]
        public void Separator_OneElements_ReturnsJustThatElement()
        {
            // Arrange
            var seq = new int[] { 1 };

            // Act
            var results = seq.Separator(0).ToList();

            // Assert
            var expected = new int[] { 1 };
            Assert.Equal(expected, results);
        }

        [Fact]
        public void Separator_TwoElements_ReturnsElementsWithSeparator()
        {
            // Arrange
            var seq = new int[] { 1, 2 };

            // Act
            var results = seq.Separator(0).ToList();

            // Assert
            var expected = new int[] { 1, 0, 2 };
            Assert.Equal(expected, results);
        }
    }
}
