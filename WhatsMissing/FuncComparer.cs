namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;

    internal class FuncComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> comparer;

        public FuncComparer(Func<T, T, int> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return this.comparer(x, y);
        }
    }
}
