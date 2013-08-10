namespace WhatsMissing
{
    public class StandardGenerator : IRandomGenerator
    {
        private readonly System.Random generator;

        public StandardGenerator()
        {
            this.generator = new System.Random();
        }

        public StandardGenerator(int seed)
        {
            this.generator = new System.Random(seed);
        }

        public int Next()
        {
            return this.generator.Next();
        }

        public int Next(int maxValue)
        {
            return this.generator.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return this.generator.Next(minValue, maxValue);
        }

        public void NextBytes(byte[] buffer)
        {
            this.generator.NextBytes(buffer);
        }

        public double NextDouble()
        {
            return this.generator.NextDouble();
        }
    }
}
