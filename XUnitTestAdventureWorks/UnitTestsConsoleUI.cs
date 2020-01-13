using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestAdventureWorks
{
    public class UnitTestsConsoleUI
    {
        [Fact]
        public void TestConsole()
        {
            ConsoleUI.Console console = new ConsoleUI.Console();

            Assert.NotNull(console);
        }

        [Fact(DisplayName ="Useless test")]
        public void TestUseless()
        {
            Assert.NotNull(new object());
        }

        [Fact(DisplayName = "Another useless test")]
        public void TestAnotherUseless()
        {
            Assert.EndsWith("the end", new string("This is is the end"));
        }
    }
}
