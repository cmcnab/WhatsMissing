namespace WhatsMissing
{
    public struct HashCode
    {
        private const int Factor = 31;
        private readonly int hashCode;

        public HashCode(int hashCode)
        {
            this.hashCode = hashCode;
        }

        public static implicit operator int(HashCode hashCode)
        {
            return hashCode.GetHashCode();
        }

        public static HashCode Compose<T>(T arg)
        {
            return new HashCode(arg.GetHashCode());
        }

        public static HashCode ComposeNotNull<T>(T arg) where T : class
        {
            return new HashCode(arg == null ? Factor : arg.GetHashCode());
        }

        public HashCode And<T>(T arg)
        {
            unchecked
            {
                return new HashCode((this.hashCode * Factor) + arg.GetHashCode());
            }
        }

        public HashCode AndNotNull<T>(T arg)
        {
            unchecked
            {
                return new HashCode((this.hashCode * Factor) + (arg == null ? 0 : arg.GetHashCode()));
            }
        }

        public override int GetHashCode()
        {
            return this.hashCode;
        }
    }
}
