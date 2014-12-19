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

        public static IEqualityComparer<T> With<T>(Func<T, T, bool> equality, Func<T, int> hashCode)
        {
            return new FuncEqualityComparer<T>(equality, hashCode);
        }

        public static IComparer<T> With<T>(Func<T, T, int> comparer)
        {
            return new FuncComparer<T>(comparer);
        }

        public static IComparer<T> WithLessThan<T>(Func<T, T, bool> lessThan)
        {
            Func<T, T, int> comparer = (a, b) =>
                {
                    if (lessThan(a, b))
                    {
                        if (lessThan(b, a))
                        {
                            throw new InvalidOperationException();
                        }

                        return -1;
                    }
                    else
                    {
                        // !(a < b) && !(b < a) means a == b
                        return lessThan(b, a) ? 1 : 0;
                    }
                };

            return new FuncComparer<T>(comparer);
        }

        public static IEqualityComparer<double> Doubles(int precision)
        {
            if (precision < 0)
            {
                throw new ArgumentOutOfRangeException("precision", precision, "Precision must be zero or positive");
            }

            double delta = Math.Pow(10.0, -precision);
            return Compare.With<double>((a, b) => Math.Abs(b - a) < delta);
        }
    }
}
