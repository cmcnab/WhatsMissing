namespace WhatsMissing
{
    using System;

    // TODO: make a separate WhatsMissing.Testing assembly?
    public class FakeTimeSource : ITimeSource
    {
        private readonly DateTime epoch;
        private DateTime utcNow;

        public FakeTimeSource()
            : this(new DateTime(1970, 1, 1, 0, 0, 0))
        {
        }

        public FakeTimeSource(DateTime epoch)
        {
            this.epoch = epoch;
            this.utcNow = epoch;
        }

        public DateTime Epoch
        {
            get { return this.epoch; }
        }

        public DateTime UtcNow
        {
            get { return this.utcNow; }
            set { this.utcNow = value; }
        }

        public FakeTimeSource Sleep(int milliseconds)
        {
            this.utcNow = this.utcNow.AddMilliseconds((double)milliseconds);
            return this;
        }
    }
}
