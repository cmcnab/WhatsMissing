namespace WhatsMissing.Tests
{
    using System;
    using Xunit;

    public class DateTimeExtensionsTests
    {
        [Fact]
        public void RangeToCreatesDateTimeRange()
        {
            // Arrange
            var startDate = new DateTime(2012, 1, 1);
            var endDate = new DateTime(2013, 1, 1);

            // Act
            var range = startDate.RangeTo(endDate);

            // Assert
            Assert.Equal(startDate, range.Start);
            Assert.Equal(endDate, range.End);
        }

        [Fact]
        public void IsInChecksDateTimeRangeContains()
        {
            // Arrange
            var range = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var date = new DateTime(2012, 2, 15);

            // Act
            bool isInRange = date.IsIn(range);

            // Assert
            Assert.True(isInRange);
        }

        [Fact]
        public void IsInIsInclusiveOnStart()
        {
            // Arrange
            var range = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var date = range.Start;

            // Act
            bool isInRange = date.IsIn(range);

            // Assert
            Assert.True(isInRange);
        }

        [Fact]
        public void IsInIsNotInclusiveOnEnd()
        {
            // Arrange
            var range = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var date = range.End;

            // Act
            bool isInRange = date.IsIn(range);

            // Assert
            Assert.False(isInRange);
        }
    }
}
