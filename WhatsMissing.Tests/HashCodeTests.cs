namespace WhatsMissing.Tests
{
    using Xunit;

    public class HashCodeTests
    {
        [Fact]
        public void HashCode_2ObjectsWithNulls_AreEqual()
        {
            // Arrange
            var obj1 = new AClass(null, 0);
            var obj2 = new AClass(null, 0);

            // Act
            var hash1 = obj1.GetHashCode();
            var hash2 = obj2.GetHashCode();
            
            // Assert
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void HashCode_1ObjectWith1Not_AreNotEqual()
        {
            // Arrange
            var obj1 = new AClass(null, 0);
            var obj2 = new AClass("foo", 3);

            // Act
            var hash1 = obj1.GetHashCode();
            var hash2 = obj2.GetHashCode();

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        [Fact]
        public void HashCode_ObjectsDiffOrder_AreNotEqual()
        {
            // Arrange
            var obj1 = new AClass("foo", 3);
            var obj2 = new BClass(3, "foo");

            // Act
            var hash1 = obj1.GetHashCode();
            var hash2 = obj2.GetHashCode();

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        private class AClass
        {
            private string s;
            private int i;

            public AClass(string s, int i)
            {
                this.s = s;
                this.i = i;
            }

            public override int GetHashCode()
            {
                return HashCode.ComposeNotNull(this.s).And(this.i);
            }
        }

        private class BClass
        {
            private int i;
            private string s;

            public BClass(int i, string s)
            {
                this.i = i;
                this.s = s;
            }

            public override int GetHashCode()
            {
                return HashCode.Compose(this.i).AndNotNull(this.s);
            }
        }
    }
}
