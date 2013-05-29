namespace WhatsMissing.Time
{
    using System;

    public static class DateTimeExtensions
    {
        //public static DateTime JSTimeToDate(this long milli)
        //{
        //    return Epoch + TimeSpan.FromMilliseconds((double)milli);
        //}

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
            return dateRange.Start <= dateTime && dateTime <= dateRange.End;
        }
    }
}
