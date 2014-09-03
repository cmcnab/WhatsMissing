namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static IList<T> RemoveFirst<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (int index = 0; index < list.Count; ++index)
            {
                if (predicate(list[index]))
                {
                    list.RemoveAt(index);
                    break;
                }
            }

            return list;
        }
    }
}
