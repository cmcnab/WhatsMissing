namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public static IEnumerable<Tuple<T, T>> Pairwise<T>(this IEnumerable<T> sequence)
        {
            T previous = default(T);

            using (var it = sequence.GetEnumerator())
            {
                if (it.MoveNext())
                {
                    previous = it.Current;
                }
                else
                {
                    yield break;
                }

                while (it.MoveNext())
                {
                    yield return Tuple.Create(previous, it.Current);
                    previous = it.Current;
                }
            }
        }

        public static IEnumerable<T> Separator<T>(this IEnumerable<T> sequence, T separator)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            using (var it = sequence.GetEnumerator())
            {
                if (!it.MoveNext())
                {
                    yield break;
                }

                yield return it.Current;
                while (it.MoveNext())
                {
                    yield return separator;
                    yield return it.Current;
                }
            }
        }
    }
}
