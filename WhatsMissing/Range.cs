namespace WhatsMissing
{
    using System;

    public static class Range
    {
        public static Range<T> Create<T>(T value1, T value2) where T : IEquatable<T>, IComparable<T>
        {
            return new Range<T>(value1, value2);
        }
    }
}
