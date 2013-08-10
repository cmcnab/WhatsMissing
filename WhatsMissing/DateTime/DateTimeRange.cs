namespace WhatsMissing
{
    using System;

    public struct DateTimeRange : IEquatable<DateTimeRange>
    {
        private readonly DateTime start;
        private readonly DateTime end;

        public DateTimeRange(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        public DateTimeRange(DateTimeRange other)
            : this(other.start, other.end)
        {
        }

        public DateTime Start
        {
            get { return this.start; }
        }

        public DateTime End
        {
            get { return this.end; }
        }

        public DateTime EarlyDate
        {
            get { return this.IsForward ? this.start : this.end; }
        }

        public DateTime LateDate
        {
            get { return this.IsForward ? this.end : this.start; }
        }

        public bool IsForward
        {
            get { return this.start <= this.end; }
        }

        public TimeSpan Span
        {
            get { return this.end - this.start; }
        }

        public static bool operator ==(DateTimeRange range1, DateTimeRange range2)
        {
            return range1.Equals(range2);
        }

        public static bool operator !=(DateTimeRange range1, DateTimeRange range2)
        {
            return !range1.Equals(range2);
        }

        public bool Contains(DateTime date)
        {
            return this.Contains(date, true, false);
        }

        public bool Contains(DateTime date, bool inclusiveStart, bool inclusiveEnd)
        {
            bool matchStart = inclusiveStart ? this.start <= date : this.start < date;
            bool matchEnd = inclusiveEnd ? date <= this.end : date < this.end;
            return matchStart && matchEnd;
        }

        public bool Overlaps(DateTimeRange other)
        {
            return this.Overlaps(other, true);
        }

        public bool Overlaps(DateTimeRange other, bool inclusive)
        {
            return this.Contains(other.Start, inclusive, false) // Check if either of the other's dates are inside mine.
                || this.Contains(other.End, inclusive, false)
                || other.Contains(this.Start, inclusive, false) // Check if either of my dates are inside the other's.
                || other.Contains(this.End, inclusive, false)
                || this.Equals(other); // Check if our dates are exactly equal (if inclusive is false this case would not be caught above).
        }

        public DateTimeRange? Intersection(DateTimeRange other)
        {
            var low1 = this.EarlyDate;
            var high1 = this.LateDate;
            var low2 = other.EarlyDate;
            var high2 = other.LateDate;

            if (low2 < high1 && high2 > low1)
            {
                var conflictLow = low2 < low1 ? low1 : low2;
                var conflictHigh = high2 > high1 ? high1 : high2;

                // Note the returned range preserves the directionality of this range.
                return this.IsForward
                    ? new DateTimeRange(conflictLow, conflictHigh)
                    : new DateTimeRange(conflictHigh, conflictLow);
            }

            return null;
        }

        public DateTimeRange Union(DateTimeRange other)
        {
            var earliest = this.EarlyDate <= other.EarlyDate ? this.EarlyDate : other.EarlyDate;
            var latest = this.LateDate > other.LateDate ? this.LateDate : other.LateDate;
            return this.IsForward
                ? new DateTimeRange(earliest, latest)
                : new DateTimeRange(latest, earliest);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this.Equals((DateTimeRange)obj);
        }

        public bool Equals(DateTimeRange other)
        {
            return this.Start == other.Start && this.End == other.End;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Start.GetHashCode();
            hash = (hash * 7) + this.End.GetHashCode();
            return hash;
        }
    }
}
