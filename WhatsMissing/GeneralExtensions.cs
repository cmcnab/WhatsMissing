namespace WhatsMissing
{
    using System;

    public static class GeneralExtensions
    {
        public static R IfNotNull<T, R>(this T obj, Func<T, R> fn) where T : class
        {
            return obj == null ? default(R) : fn(obj);
        }

        public static R IfNotNull<T, R>(this T obj, Func<T, R> fn, R defaultValue) where T : class
        {
            return obj == null ? defaultValue : fn(obj);
        }

        public static R IfHasValue<T, R>(this T? obj, Func<T, R> fn) where T : struct
        {
            return !obj.HasValue ? default(R) : fn(obj.Value);
        }

        public static R IfHasValue<T, R>(this T? obj, Func<T, R> fn, R defaultValue) where T : struct
        {
            return !obj.HasValue ? defaultValue : fn(obj.Value);
        }
    }
}
