namespace WhatsMissing
{
    using System;

    public interface ITimeSource
    {
        DateTime UtcNow { get; }
    }
}
