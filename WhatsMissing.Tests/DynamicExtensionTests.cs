namespace WhatsMissing.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class DynamicExtensionTests
    {
        [Fact]
        public void Extend_TwoAnonObjects_CombinesProperties()
        {
            // Arrange
            var obj1 = new { PropA1 = "a", PropA2 = 2 };
            var obj2 = new { PropB1 = 33.3 };

            // Act
            dynamic result = obj1.Extend(obj2);

            // Assert
            var props = (IDictionary<string, object>)result;
            Assert.Equal(3, props.Count);

            var propA1 = props["PropA1"];
            Assert.Equal(typeof(string), propA1.GetType());
            Assert.Equal("a", propA1);

            var propA2 = props["PropA2"];
            Assert.Equal(typeof(int), propA2.GetType());
            Assert.Equal(2, propA2);

            var propA3 = props["PropB1"];
            Assert.Equal(typeof(double), propA3.GetType());
            Assert.Equal(33.3, propA3);
        }
    }
}
