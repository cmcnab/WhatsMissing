namespace WhatsMissing.Time
{
    using System;

    public interface ITimeSource
    {
        DateTime UtcNow { get; }
    }
}
