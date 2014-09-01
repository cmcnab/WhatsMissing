namespace WhatsMissing
{
    using System;

    public interface ITimeSource
    {
        DateTime UtcNow { get; }

        /// <summary>
        /// Gets a System.DateTimeOffset object that is set to the current date and time
        /// on the current computer, with the offset set to the local time's offset from
        /// Coordinated Universal Time (UTC).
        /// </summary>
        DateTimeOffset OffsetNow { get; }

        /// <summary>
        /// Gets a System.DateTimeOffset object whose date and time are set to the current
        /// Coordinated Universal Time (UTC) date and time and whose offset is System.TimeSpan.Zero.
        /// </summary>
        DateTimeOffset OffsetUtcNow { get; }
    }
}
