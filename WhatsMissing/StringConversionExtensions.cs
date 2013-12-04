namespace WhatsMissing
{
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

        #region Double

        public static double? AsDouble(this string s)
        {
            int result;
            if (!string.IsNullOrEmpty(s) && int.TryParse(s, out result))
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
    }
}
