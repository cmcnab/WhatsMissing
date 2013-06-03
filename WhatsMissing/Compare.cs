namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;

    public static class Compare
    {
        public static IEqualityComparer<T> With<T>(Func<T, T, bool> equality)
        {
            return new FuncEqualityComparer<T>(equality);
        }

        public static IComparer<T> With<T>(Func<T, T, int> comparer)
        {
            return new FuncComparer<T>(comparer);
        }
    }
}
