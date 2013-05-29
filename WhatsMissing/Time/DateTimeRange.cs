namespace WhatsMissing.Time
{
    using System;

    public struct DateTimeRange
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
    }
}
