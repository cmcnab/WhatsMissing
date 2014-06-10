namespace WhatsMissing
{
    using System;

    public class Range<T> : IEquatable<Range<T>> where T : IEquatable<T>, IComparable<T>
    {
        private readonly T start;
        private readonly T end;

        public Range(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public Range(Range<T> other)
            : this(other.start, other.end)
        {
        }

        public T Start
        {
            get { return this.start; }
        }

        public T End
        {
            get { return this.end; }
        }

        public T Lesser
        {
            get { return this.IsForward ? this.start : this.end; }
        }

        public T Greater
        {
            get { return this.IsForward ? this.end : this.start; }
        }

        public bool IsForward
        {
            get { return this.start.CompareTo(this.end) <= 0; }
        }

        public static bool operator ==(Range<T> range1, Range<T> range2)
        {
            return CheckEquals(range1, range2);
        }

        public static bool operator !=(Range<T> range1, Range<T> range2)
        {
            return !CheckEquals(range1, range2);
        }

        public override bool Equals(object obj)
        {
            return CheckEquals(this, obj as Range<T>);
        }

        public bool Equals(Range<T> other)
        {
            return CheckEquals(this, other);
        }

        public override int GetHashCode()
        {
            return HashCode.Compose(this.Start).And(this.End);
        }

        public bool Contains(T value)
        {
            return this.Contains(value, true, false);
        }

        public bool Contains(T value, bool inclusiveStart, bool inclusiveEnd)
        {
            bool matchStart = inclusiveStart ? this.Start.CompareTo(value) <= 0 : this.Start.CompareTo(value) < 0;
            bool matchEnd = inclusiveEnd ? value.CompareTo(this.End) <= 0 : value.CompareTo(this.End) < 0;
            return matchStart && matchEnd;
        }

        public bool Overlaps(Range<T> other)
        {
            return this.Overlaps(other, true);
        }

        public bool Overlaps(Range<T> other, bool inclusive)
        {
            return this.Contains(other.Start, inclusive, false) // Check if either of the other's values are inside mine.
                || this.Contains(other.End, inclusive, false)
                || other.Contains(this.Start, inclusive, false) // Check if either of my values are inside the other's.
                || other.Contains(this.End, inclusive, false)
                || this.Equals(other); // Check if our values are exactly equal (if inclusive is false this case would not be caught above).
        }

        public Range<T> Intersection(Range<T> other)
        {
            var low1 = this.Lesser;
            var high1 = this.Greater;
            var low2 = other.Lesser;
            var high2 = other.Greater;

            if (low2.CompareTo(high1) < 0 && high2.CompareTo(low1) > 0)
            {
                var conflictLow = low2.CompareTo(low1) < 0 ? low1 : low2;
                var conflictHigh = high2.CompareTo(high1) > 0 ? high1 : high2;

                // Note the returned range preserves the directionality of this range.
                return this.IsForward
                    ? new Range<T>(conflictLow, conflictHigh)
                    : new Range<T>(conflictHigh, conflictLow);
            }

            return null;
        }

        public Range<T> Union(Range<T> other)
        {
            var least = this.Lesser.CompareTo(other.Lesser) <= 0 ? this.Lesser : other.Lesser;
            var greatest = this.Greater.CompareTo(other.Greater) > 0 ? this.Greater : other.Greater;
            return this.IsForward
                ? new Range<T>(least, greatest)
                : new Range<T>(greatest, least);
        }

        public Range<T> Reverse()
        {
            return new Range<T>(this.end, this.start);
        }

        public Range<TResult> Map<TResult>(Func<T, TResult> selector)
            where TResult : IEquatable<TResult>, IComparable<TResult>
        {
            return new Range<TResult>(selector(this.start), selector(this.end));
        }

        private static bool CheckEquals(Range<T> range1, Range<T> range2)
        {
            if (ReferenceEquals(range1, range2))
            {
                return true;
            }

            if (ReferenceEquals(range1, null) || ReferenceEquals(range2, null))
            {
                return false;
            }

            return range1.Start.Equals(range2.Start)
                && range1.End.Equals(range2.End);
        }
    }
}
