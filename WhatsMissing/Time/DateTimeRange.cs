namespace WhatsMissing.Time
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

        public override bool Equals(object obj)
        {
            return this.Equals((DateTimeRange)obj);
        }

        public bool Equals(DateTimeRange other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

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
