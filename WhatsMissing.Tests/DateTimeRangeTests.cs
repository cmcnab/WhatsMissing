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
        // -------------------- Equality Tests --------------------
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

        [Fact]
        public void EqualsRangesHaveSameHashCode()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            var hash1 = range1.GetHashCode();
            var hash2 = range2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void DifferentRangesHaveDifferentHashCodes()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 2, 1), new DateTime(2013, 2, 1));

            // Act
            var hash1 = range1.GetHashCode();
            var hash2 = range2.GetHashCode();

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        // -------------------- Contains Tests --------------------
        [Fact]
        public void DateUnambigouslyInsideContainsIsTrue()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
            DateTime date = new DateTime(2012, 1, 15);

            // Act
            bool isInRange = range.Contains(date);

            // Assert
            Assert.True(isInRange);
        }

        [Fact]
        public void ContainsInclusiveStartExactlyStartIsTrue()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
            DateTime date = range.Start;

            // Act
            bool isInRange = range.Contains(date, true, false);

            // Assert
            Assert.True(isInRange);
        }

        [Fact]
        public void ContainsNotInclusiveStartExactlyStartIsFalse()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
            DateTime date = range.Start;

            // Act
            bool isInRange = range.Contains(date, false, false);

            // Assert
            Assert.False(isInRange);
        }

        [Fact]
        public void ContainsInclusiveEndExactlyEndIsTrue()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
            DateTime date = range.End;

            // Act
            bool isInRange = range.Contains(date, true, true);

            // Assert
            Assert.True(isInRange);
        }

        [Fact]
        public void ContainsNotInclusiveEndExactlyEndIsFalse()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
            DateTime date = range.End;

            // Act
            bool isInRange = range.Contains(date, false, false);

            // Assert
            Assert.False(isInRange);
        }

        // -------------------- Overlaps Tests --------------------
        [Fact]
        public void NonButtingRangesNotInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void NonButtingRangesInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void ButtingLeftRangesNotInclusiveDoesntOverlap()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.False(overlaps);
        }

        [Fact]
        public void ButtingLeftRangesInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void ButtingRightRangesNotInclusiveDoesntOverlap()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.False(overlaps);
        }

        [Fact]
        public void ButtingRightRangesInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void InsideRangeInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void InsideRangeNonInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void EqualRangesInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void EqualRangesNotInclusiveOverlaps()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            DateTimeRange range2 = new DateTimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        // -------------------- Misc Tests --------------------
        [Fact]
        public void CopyConstructorCopiesBothDates()
        {
            // Arrange
            DateTimeRange range1 = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));

            // Act
            DateTimeRange range2 = new DateTimeRange(range1);

            // Assert
            Assert.Equal(range1.Start, range2.Start);
            Assert.Equal(range1.End, range2.End);
        }

        [Fact]
        public void SpanCalculatesDateDiff()
        {
            // Arrange
            DateTimeRange range = new DateTimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));

            // Act / Assert
            var diff = range.End - range.Start;
            Assert.Equal(diff, range.Span);
        }
    }
}
