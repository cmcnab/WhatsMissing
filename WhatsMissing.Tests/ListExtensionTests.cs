namespace WhatsMissing.Tests
{
    using System;
    using Xunit;

    public class ListExtensionTests
    {
        [Fact]
        public void RemoveFirst_Exists_ItemRemoved()
        {
            // Arrange
            var input = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("two", 2),
                Tuple.Create("three", 3));

            // Act
            input.RemoveFirst(t => t.Item2 == 2);

            // Assert
            var expected = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("three", 3));
            Assert.Equal(expected, input);
        }

        [Fact]
        public void RemoveFirst_DoesntExist_NoChange()
        {
            // Arrange
            var input = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("two", 2),
                Tuple.Create("three", 3));

            // Act
            input.RemoveFirst(t => t.Item2 == 4);

            // Assert
            var expected = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("two", 2),
                Tuple.Create("three", 3));
            Assert.Equal(expected, input);
        }

        [Fact]
        public void RemoveFirst_MultipleExist_OnlyFirstRemoved()
        {
            // Arrange
            var input = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("two", 2),
                Tuple.Create("three", 3),
                Tuple.Create("two", 2));

            // Act
            input.RemoveFirst(t => t.Item2 == 2);

            // Assert
            var expected = Params.List(
                Tuple.Create("one", 1),
                Tuple.Create("three", 3),
                Tuple.Create("two", 2));
            Assert.Equal(expected, input);
        }
    }
}
