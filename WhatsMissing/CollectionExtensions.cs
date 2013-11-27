﻿namespace WhatsMissing
{
    using System.Collections.Generic;

    public static class CollectionExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
