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

        [Fact]
        public void Reverse_SwapsStartAndEnd()
        {
            // Arrange
            var range1 = Range.Create(1, 2);

            // Act
            var result = range1.Reverse();

            // Assert
            Assert.Equal(2, result.Start);
            Assert.Equal(1, result.End);
        }

        [Fact]
        public void Map_SameType_IsApplied()
        {
            // Arrange
            var range1 = Range.Create(1, 2);

            // Act
            var result = range1.Map(i => i + 1);

            // Assert
            Assert.Equal(2, result.Start);
            Assert.Equal(3, result.End);
        }

        [Fact]
        public void Map_DifferentType_IsApplied()
        {
            // Arrange
            var range1 = Range.Create(1, 2);

            // Act
            var result = range1.Map(i => i * 3.0);

            // Assert
            Assert.Equal(typeof(double), result.Start.GetType());
            Assert.Equal(3.0, result.Start);
            Assert.Equal(6.0, result.End);
        }

        [Fact]
        public void PercentOf_Int_IsCorrect()
        {
            // Arrange
            var range1 = Range.Create(0, 10);

            // Act
            var result = range1.PercentOf(5);

            // Assert
            Assert.Equal(0.5, result);
        }
    }
}
