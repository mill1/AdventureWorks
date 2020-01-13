using AdventureWorks.Methods;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace XUnitTestAdventureWorks
{
    public class UnitTestsLinq
    {
        [Fact]
        public void TestAggregate1()
        {
            Linq linqMethod = new Linq();
            Assert.Equal("Lynden Britton III", linqMethod.Aggregate1());
        }

        [Fact]
        public void TestAll()
        {
            Linq linqMethod = new Linq();

            int i = 9;

            Assert.Equal($"All cassier names are at least {i} chars long", linqMethod.All(i));

            i++;
            Assert.Equal($"Not all cassier names are at least {i} chars long", linqMethod.All(i));
        }


        [Fact]
        public void TestAny()
        {
            Linq linqMethod = new Linq();
            string input = "0.26";

            Assert.Equal($"Articles cheaper than {input} have been sold.", linqMethod.Any(input));

            input = "0.25";
            Assert.Equal($"Articles cheaper than {input} have not been sold.", linqMethod.Any(input));
        }

        [Fact]
        public void TestConcat()
        {
            Linq linqMethod = new Linq();

            IEnumerable<string> list = linqMethod.Concat().ToList();

            list = list.Skip(15);

            Assert.Collection(list, item => Assert.Contains("85413214-258465", item),
                                    item => Assert.Contains("435413214-258464", item),
                                    item => Assert.Contains("24413214-2584555", item));
        }

    }
}
