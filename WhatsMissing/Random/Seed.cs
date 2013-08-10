namespace WhatsMissing.Random
{
    public static class Seed
    {
        public static int FromNow(ITimeSource timeSource)
        {
            // TODO: vet this
            return (int)(timeSource.UtcNow.ToJavaScriptDate().Value / 1000);
        }
    }
}
