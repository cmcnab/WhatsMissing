namespace WhatsMissing.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class DictionaryExtensionTests
    {
        [Fact]
        public void AccumulateCounter_One_ResultsInSingleItem()
        {
            // Arrange
            var dict = new Dictionary<string, int>();

            // Act
            dict.Accumulate("key1", 42);

            // Assert
            Assert.Equal(1, dict.Count);
            Assert.Equal(42, dict["key1"]);
        }

        [Fact]
        public void AccumulateCounter_Two_ResultsInAddedValue()
        {
            // Arrange
            var dict = new Dictionary<string, int>();
            dict.Add("key1", 12);

            // Act
            dict.Accumulate("key1", 42);

            // Assert
            Assert.Equal(1, dict.Count);
            Assert.Equal(54, dict["key1"]);
        }

        [Fact]
        public void AccumulateList_One_ResultsInSingleItem()
        {
            // Arrange
            var dict = new Dictionary<string, List<string>>();

            // Act
            dict.Accumulate("key1", "value1");

            // Assert
            Assert.Equal(1, dict.Count);
            Assert.Equal(Params.Get("value1"), dict["key1"]);
        }

        [Fact]
        public void AccumulateList_Two_ResultsInAppendedList()
        {
            // Arrange
            var dict = new Dictionary<string, List<string>>();

            // Act
            dict.Accumulate("key1", "value1");
            dict.Accumulate("key1", "value2");

            // Assert
            Assert.Equal(1, dict.Count);
            Assert.Equal(Params.Get("value1", "value2"), dict["key1"]);
        }
    }
}
