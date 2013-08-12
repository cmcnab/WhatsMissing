namespace WhatsMissing
{
    using System.Collections.Generic;

    public static class Params
    {
        public static T[] Get<T>(params T[] args)
        {
            return args;
        }

        public static List<T> List<T>(params T[] args)
        {
            return new List<T>(args);
        }
    }
}
