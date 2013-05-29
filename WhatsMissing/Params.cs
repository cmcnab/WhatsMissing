namespace WhatsMissing
{
    public static class Params
    {
        public static T[] Get<T>(params T[] args)
        {
            return args;
        }
    }
}
