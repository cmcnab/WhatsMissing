namespace WhatsMissing.Tests
{
    using System;
    using Xunit;

    public class CompareTests
    {
        [Fact]
        public void CompareDouble_Precision0LessThanOne_Equal()
        {
            Assert.Equal(1, 1.2, Compare.Doubles(0));
        }

        [Fact]
        public void CompareDouble_Precision0MoreThanOne_NotEqual()
        {
            Assert.NotEqual(1, 2.2, Compare.Doubles(0));
        }

        [Fact]
        public void CompareDouble_Precision1LessThanTenth_Equal()
        {
            Assert.Equal(0.1, 0.12, Compare.Doubles(1));
        }

        [Fact]
        public void CompareDouble_Precision1MoreThanTenth_NotEqual()
        {
            Assert.NotEqual(0.1, 0.22, Compare.Doubles(1));
        }

        [Fact]
        public void CompareDouble_Precision2LessThanHundreth_Equal()
        {
            Assert.Equal(0.10, 0.102, Compare.Doubles(2));
        }

        [Fact]
        public void CompareDouble_Precision1MoreThanHundreth_NotEqual()
        {
            Assert.NotEqual(0.10, 0.202, Compare.Doubles(2));
        }

        [Fact]
        public void CompareDouble_PrecisionNegative_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Compare.Doubles(-1).Equals(0.0, 1.0));
        }
    }
}
