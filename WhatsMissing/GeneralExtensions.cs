namespace WhatsMissing
{
    using System;

    public static class GeneralExtensions
    {
        public static R IfNotNull<T, R>(this T obj, Func<T, R> fn) where T : class
        {
            return obj == null ? default(R) : fn(obj);
        }
    }
}
