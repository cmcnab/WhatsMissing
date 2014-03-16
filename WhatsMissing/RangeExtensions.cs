namespace WhatsMissing
{
    using System;

    public static class RangeExtensions
    {
        public static decimal Span(this Range<decimal> range)
        {
            return range.End - range.Start;
        }

        public static double Span(this Range<double> range)
        {
            return range.End - range.Start;
        }

        public static float Span(this Range<float> range)
        {
            return range.End - range.Start;
        }

        public static int Span(this Range<int> range)
        {
            return range.End - range.Start;
        }

        public static long Span(this Range<long> range)
        {
            return range.End - range.Start;
        }

        public static TimeSpan Span(this Range<DateTime> range)
        {
            return range.End - range.Start;
        }
    }
}
