namespace WhatsMissing
{
    using System;

    public class SystemTimeSource : ITimeSource
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
