namespace WhatsMissing.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class CollectionExtensionTests
    {
        [Fact]
        public void AddRange_HashSet_ItemsAdded()
        {
            // Arrange
            var collection = new HashSet<int>();
            var input = Params.Get(1, 2, 3, 2);

            // Act
            collection.AddRange(input);

            // Assert
            Assert.Equal(Params.Get(1, 2, 3), collection);
        }
    }
}
