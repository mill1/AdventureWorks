using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using AdventureWorks.Methods.Extensions;

namespace XUnitTestAdventureWorks
{
    public class UnitTestsExtensions
    {
        [Fact]
        public void TestStringWordCount()
        {
            string s = "Test String Word Count";
            Assert.Equal(4, s.WordCount());
        }

        [Fact]
        public void TestStringLeft()
        {
            string s = "Test String Left";
            Assert.Equal("Test", s.Left(4));
        }

        [Fact]
        public void TestStringLeftError()
        {
            string s = "Test String Left";
            Assert.Equal("Length cannot be less than zero.\r\nParameter name: length", s.Left(-1));
        }

        [Fact]
        public void TestStringMid()
        {
            string s = "Test String Mid";
            Assert.Equal("tring", s.Mid(6, 5));
        }

        [Fact]
        public void TestLinqMedian()
        {
            Assert.Equal(2.55, new double[3] { 1.46, 4.21, 2.55 }.Median());
        }

        [Fact]
        public void TestLinqMedianException()
        {
            Assert.Throws<InvalidOperationException>(() => new List<double>().Median());
        }

        [Fact]
        public void TestLinqTakeEvery()
        {
            var values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Assert.Equal(9, values.TakeEvery(3, 1).Count());
            Assert.Equal("AKU", string.Join("", values.TakeEvery(10, 0)));
        }

        [Fact]
        public void TestLinqTakeEveryException()
        {
            var values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Assert.Throws<ArgumentException>(() => values.TakeEvery(0, 1).ToArray());
        }
    }
}
