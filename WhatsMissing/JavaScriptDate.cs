namespace WhatsMissing
{
    using System;

    public struct JavaScriptDate
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0);

        private readonly long milliseconds;

        public JavaScriptDate(long milliseconds)
        {
            this.milliseconds = milliseconds;
        }

        public JavaScriptDate(DateTime dateTime)
        {
            this.milliseconds = (long)(dateTime - Epoch).TotalMilliseconds;
        }

        public long Value
        {
            get { return this.milliseconds; }
        }

        public DateTime ToDateTime()
        {
            return Epoch + TimeSpan.FromMilliseconds((double)this.milliseconds);
        }
    }
}
