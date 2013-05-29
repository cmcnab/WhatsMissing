namespace WhatsMissing.Time
{
    using System;

    public class DateTimeRange
    {
        private readonly DateTime start;
        private readonly DateTime end;

        public DateTimeRange(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        public DateTime Start
        {
            get { return this.start; }
        }

        public DateTime End
        {
            get { return this.end; }
        }
    }
}
