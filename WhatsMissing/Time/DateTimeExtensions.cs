namespace WhatsMissing.Time
{
    using System;

    public static class DateTimeExtensions
    {
        public static JavaScriptDate ToJavaScriptDate(this DateTime dateTime)
        {
            return new JavaScriptDate(dateTime);
        }

        public static DateTimeRange RangeTo(this DateTime start, DateTime end)
        {
            return new DateTimeRange(start, end);
        }

        public static bool IsIn(this DateTime dateTime, DateTimeRange dateRange)
        {
            return dateRange.Contains(dateTime);
        }
    }
}
