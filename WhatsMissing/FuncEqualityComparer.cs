namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;

    internal class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> equality;
        private readonly Func<T, int> hashCode;

        public FuncEqualityComparer(Func<T, T, bool> equality)
            : this(equality, o => o.GetHashCode())
        {
        }

        public FuncEqualityComparer(Func<T, T, bool> equality, Func<T, int> hashCode)
        {
            this.equality = equality;
            this.hashCode = hashCode;
        }

        public bool Equals(T x, T y)
        {
            return this.equality(x, y);
        }

        public int GetHashCode(T obj)
        {
            return this.hashCode(obj);
        }
    }
}
