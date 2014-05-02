namespace WhatsMissing
{
    using System;
    using System.Globalization;

    public static class StringConversionExtensions
    {
        #region String

        public static string EmptyIfNull(this string s)
        {
            return s == null ? string.Empty : s;
        }

        #endregion

        #region Bool

        public static bool? AsBool(this string s)
        {
            bool result;
            if (!string.IsNullOrEmpty(s) && bool.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static bool AsBoolOrDefault(this string s)
        {
            return AsBoolOrDefault(s, default(bool));
        }

        public static bool AsBoolOrDefault(this string s, bool defaultValue)
        {
            var result = AsBool(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion

        #region Int

        public static int? AsInt(this string s)
        {
            int result;
            if (!string.IsNullOrEmpty(s) && int.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static int AsIntOrDefault(this string s)
        {
            return AsIntOrDefault(s, default(int));
        }

        public static int AsIntOrDefault(this string s, int defaultValue)
        {
            var result = AsInt(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion

        #region Long

        public static long? AsLong(this string s)
        {
            long result;
            if (!string.IsNullOrEmpty(s) && long.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static long AsLongOrDefault(this string s)
        {
            return AsLongOrDefault(s, default(long));
        }

        public static long AsLongOrDefault(this string s, long defaultValue)
        {
            var result = AsLong(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion

        #region Double

        public static double? AsDouble(this string s)
        {
            double result;
            if (!string.IsNullOrEmpty(s) && double.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static double AsDoubleOrDefault(this string s)
        {
            return AsDoubleOrDefault(s, default(double));
        }

        public static double AsDoubleOrDefault(this string s, double defaultValue)
        {
            var result = AsDouble(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion

        #region Decimal

        public static decimal? AsDecimal(this string s)
        {
            decimal result;
            if (!string.IsNullOrEmpty(s) && decimal.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static decimal AsDecimalOrDefault(this string s)
        {
            return AsDecimalOrDefault(s, default(decimal));
        }

        public static decimal AsDecimalOrDefault(this string s, decimal defaultValue)
        {
            var result = AsDecimal(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion

        #region DateTime

        public static DateTime? AsDateTime(this string s)
        {
            DateTime result;
            if (!string.IsNullOrEmpty(s) && DateTime.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }

        public static DateTime? AsDateTimeRoundtripKind(this string s)
        {
            DateTime result;
            if (!string.IsNullOrEmpty(s) && DateTime.TryParse(s, null, DateTimeStyles.RoundtripKind, out result))
            {
                return result;
            }

            return null;
        }

        public static DateTime AsDateTimeOrDefault(this string s)
        {
            return AsDateTimeOrDefault(s, default(DateTime));
        }

        public static DateTime AsDateTimeOrDefault(this string s, DateTime defaultValue)
        {
            var result = AsDateTime(s);
            return result.HasValue ? result.Value : defaultValue;
        }

        #endregion
    }
}
