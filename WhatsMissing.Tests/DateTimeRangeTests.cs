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
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);
            
            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SameEqualRangesAreEqual()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = range1;

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void EqualRangesAsObjectAreEqual()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            object range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SeparateEqualRangesWithEqualsOperatorAreEqual()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1 == range2;

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SeparateEqualRangesWithNotEqualsOperatorAreNotEqual()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1 != range2;

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void RangeDoesNotEqualNull()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
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
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 2, 1), new DateTime(2013, 1, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void DifferentEndDateNotEqual()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 2, 1));

            // Act
            bool areEqual = range1.Equals(range2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualsRangesHaveSameHashCode()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));

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
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2013, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 2, 1), new DateTime(2013, 2, 1));

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
            Range<DateTime> range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
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
            Range<DateTime> range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
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
            Range<DateTime> range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
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
            Range<DateTime> range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
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
            Range<DateTime> range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));
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
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void NonButtingRangesInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void ButtingLeftRangesNotInclusiveDoesntOverlap()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.False(overlaps);
        }

        [Fact]
        public void ButtingLeftRangesInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void ButtingRightRangesNotInclusiveDoesntOverlap()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.False(overlaps);
        }

        [Fact]
        public void ButtingRightRangesInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void InsideRangeInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void InsideRangeNonInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void EqualRangesInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, true);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void EqualRangesNotInclusiveOverlaps()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2, false);

            // Assert
            Assert.True(overlaps);
        }

        [Fact]
        public void DefaultParamOverlapsIsInclusive()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));

            // Act
            var overlaps = range1.Overlaps(range2);

            // Assert
            Assert.True(overlaps);
        }

        // -------------------- Intersection Tests --------------------
        [Fact]
        public void NonOverlappingRangesReturnNoIntersection()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 4));

            // Act
            var overlapping = range1.Intersection(range2);

            // Assert
            Assert.Null(overlapping);
        }

        [Fact]
        public void NonButtingRangesLeftCorrectIntersection()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var overlapping = range1.Intersection(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            Assert.NotNull(overlapping);
            Assert.Equal(expected, overlapping);
        }

        [Fact]
        public void NonButtingRangesRightCorrectIntersection()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));

            // Act
            var overlapping = range1.Intersection(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 3));
            Assert.NotNull(overlapping);
            Assert.Equal(expected, overlapping);
        }

        [Fact]
        public void NonButtingRangesReverseLeftCorrectIntersection()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 2));

            // Act
            var overlapping = range1.Intersection(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 2));
            Assert.NotNull(overlapping);
            Assert.Equal(expected, overlapping);
        }

        [Fact]
        public void NonButtingRangesReverseRightCorrectIntersection()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 1));

            // Act
            var overlapping = range1.Intersection(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 2));
            Assert.NotNull(overlapping);
            Assert.Equal(expected, overlapping);
        }

        // -------------------- Union Tests --------------------
        [Fact]
        public void NonOverlappingRangesReturnCorrectUnion()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 4));

            // Act
            var result = range1.Union(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverlappingRangesLeftCorrectUnion()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));

            // Act
            var result = range1.Union(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverlappingRangesRightCorrectUnion()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 4));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 3));

            // Act
            var result = range1.Union(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 1), new DateTime(2012, 1, 4));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverlappingRangesReverseLeftCorrectUnion()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 1));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 2));

            // Act
            var result = range1.Union(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 1));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverlappingRangesReverseRightCorrectUnion()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 2));
            var range2 = new Range<DateTime>(new DateTime(2012, 1, 3), new DateTime(2012, 1, 1));

            // Act
            var result = range1.Union(range2);

            // Assert
            var expected = new Range<DateTime>(new DateTime(2012, 1, 4), new DateTime(2012, 1, 1));
            Assert.Equal(expected, result);
        }

        // -------------------- Misc Tests --------------------
        [Fact]
        public void CopyConstructorCopiesBothDates()
        {
            // Arrange
            var range1 = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));

            // Act
            var range2 = new Range<DateTime>(range1);

            // Assert
            Assert.Equal(range1.Start, range2.Start);
            Assert.Equal(range1.End, range2.End);
        }

        [Fact]
        public void SpanCalculatesDateDiff()
        {
            // Arrange
            var range = new Range<DateTime>(new DateTime(2012, 1, 2), new DateTime(2012, 1, 30));

            // Act / Assert
            var diff = range.End - range.Start;
            Assert.Equal(diff, range.Span());
        }
    }
}
