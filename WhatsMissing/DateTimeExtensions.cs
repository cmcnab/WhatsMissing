namespace WhatsMissing
{
    using System;
    using System.Globalization;

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

        [Obsolete("Use ToRoundtripKindString instead.")]
        public static string ToIso8601String(this DateTime datetime)
        {
            // TODO: ensure the datetime is UTC?
            return datetime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        public static string ToRoundtripKindString(this DateTime datetime)
        {
            return datetime.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}
