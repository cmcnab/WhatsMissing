namespace WhatsMissing
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtensions
    {
        public static V GetOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            V value = default(V);
            dictionary.TryGetValue(key, out value);
            return value;
        }

        public static IDictionary<K, int> Accumulate<K>(this IDictionary<K, int> dictionary, K key, int value)
        {
            return Accumulate(dictionary, key, value, (e, v) => e + v);
        }

        public static IDictionary<K, List<V>> Accumulate<K, V>(this IDictionary<K, List<V>> dictionary, K key, V value)
        {
            return Accumulate(
                dictionary, 
                key, 
                value, 
                (e, v) =>
                {
                    if (e == null)
                    {
                        e = new List<V>();
                    }

                    e.Add(v);
                    return e;
                });
        }

        public static IDictionary<K, V> Accumulate<K, V, T>(this IDictionary<K, V> dictionary, K key, T value, Func<V, T, V> accumulator)
        {
            V existingValue;
            if (dictionary.TryGetValue(key, out existingValue))
            {
                dictionary[key] = accumulator(existingValue, value);
            }
            else
            {
                dictionary[key] = accumulator(default(V), value);
            }

            return dictionary;
        }
    }
}
