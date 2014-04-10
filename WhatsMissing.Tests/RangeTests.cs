namespace WhatsMissing.Tests
{
    using Xunit;

    public class RangeTests
    {
        [Fact]
        public void EqualityOp_NullToNotNull_ReturnsFalse()
        {
            // Arrange
            Range<int> range1 = null;
            var range2 = new Range<int>(0, 1);

            // Act / Assert
            Assert.False(range1 == range2);
        }

        [Fact]
        public void EqualityOp_NotNullToNull_ReturnsFalse()
        {
            // Arrange
            var range1 = new Range<int>(0, 1);
            Range<int> range2 = null;

            // Act / Assert
            Assert.False(range1 == range2);
        }

        [Fact]
        public void InequalityOp_NullToNotNull_ReturnsTrue()
        {
            // Arrange
            Range<int> range1 = null;
            var range2 = new Range<int>(0, 1);

            // Act / Assert
            Assert.True(range1 != range2);
        }

        [Fact]
        public void InequalityOp_NotNullToNull_ReturnsTrue()
        {
            // Arrange
            var range1 = new Range<int>(0, 1);
            Range<int> range2 = null;

            // Act / Assert
            Assert.True(range1 != range2);
        }

        [Fact]
        public void RangeCreate_CanBeUsedWithImplicitType()
        {
            // Act / Assert
            Assert.Equal(new Range<int>(0, 1), Range.Create(0, 1));
        }
    }
}
