namespace WhatsMissing
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class TaskEx
    {
        public static async Task<TResult[]> WhenAllSerially<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            var results = new List<TResult>();
            foreach (var t in tasks)
            {
                results.Add(await t);
            }

            return results.ToArray();
        }
    }
}
