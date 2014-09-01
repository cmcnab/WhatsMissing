namespace WhatsMissing
{
    using System;

    public class SystemTimeSource : ITimeSource
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }

        public DateTimeOffset OffsetNow
        {
            get { return DateTimeOffset.Now; }
        }

        public DateTimeOffset OffsetUtcNow
        {
            get { return DateTimeOffset.UtcNow; }
        }
    }
}
