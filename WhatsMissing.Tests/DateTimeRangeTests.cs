namespace WhatsMissing.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class DateTimeRangeTests
    {
        [Fact]
        public void SeparateEqualRangesAreEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);
            
            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SameEqualRangesAreEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = range1;

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualRangesAsObjectAreEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            object range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SeparateEqualRangesWithEqualsOperatorAreEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1 == range2;

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SeparateEqualRangesWithNotEqualsOperatorAreNotEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1 != range2;

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void RangeDoesNotEqualNull()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            object range2 = null;

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void DifferentStartDateNotEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 2, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void DifferentEndDateNotEqual()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 2, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.False(areEqual);
        }
    }
}
