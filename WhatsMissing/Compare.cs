using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsMissing
{
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
