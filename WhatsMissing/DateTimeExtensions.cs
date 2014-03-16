namespace WhatsMissing
{
    using System;

    public static class DateTimeExtensions
    {
        public static JavaScriptDate ToJavaScriptDate(this DateTime dateTime)
        {
            return new JavaScriptDate(dateTime);
        }

        public static Range<DateTime> RangeTo(this DateTime start, DateTime end)
        {
            return new Range<DateTime>(start, end);
        }

        public static bool IsIn(this DateTime dateTime, Range<DateTime> dateRange)
        {
            return dateRange.Contains(dateTime);
        }

        public static DateTime SpecifyKind(this DateTime dateTime, DateTimeKind kind)
        {
            return DateTime.SpecifyKind(dateTime, kind);
        }
    }
}
