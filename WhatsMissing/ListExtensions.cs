namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;

    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            return list.Shuffle(new StandardGenerator());
        }

        public static IList<T> Shuffle<T>(this IList<T> list, IRandomGenerator rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                list.SwapIndicies(k, n);
            }

            return list;
        }

        public static IList<T> SwapIndicies<T>(this IList<T> list, int indexA, int indexB)
        {
            if (indexA != indexB)
            {
                T value = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = value;
            }

            return list;
        }
    }
}
