namespace WhatsMissing
{
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> sequence)
        {
            while (true)
            {
                foreach (var item in sequence)
                {
                    yield return item;
                }
            }
        }
    }
}
