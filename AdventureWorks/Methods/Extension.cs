using AdventureWorks.Methods.Extensions;
using AdventureWorks.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventureWorks.Methods
{
    public class Extension : IMethodsClass
    {
        private Interfaces.IUI ui;

        [UIOptionAttribute]
        internal void METHEXT_String_WordCount()
        {
            string str = ui.Input("Text", new string[] {"ja nee", "aap noot mies"});
            int i = str.WordCount();

            ui.Output("Aantal woorden: " + i);
        }

        [UIOptionAttribute]
        internal void METHEXT_String_Left()
        {
            string str = ui.Input("Text:", new string[] { "Hello World!", "Ik", "Laatste tekst" });

            if (!Int32.TryParse(ui.Input("Length:", new string[] { "4", "6", "8" }), out int i))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else
                ui.Output($"Left {i} of '{str}':\n" + str.Left(i), "Result");
        }

        [UIOptionAttribute]
        internal void METHEXT_String_Mid()
        {
            string str = ui.Input("Text:", new string[] { "Hello World!", "Nog een tekst" });

            if (!Int32.TryParse(ui.Input("StartIndex:", new string[] { "-1", "2", "15" }), out int startIndex))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else if(!Int32.TryParse(ui.Input("Length:", new string[] { "0", "4", "6" }), out int length))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else
                ui.Output($"Mid {startIndex}, {length} of '{str}':\n" + str.Mid(startIndex, length), "Result");
        }

        [UIOptionAttribute]
        internal void METHEXT_Linq_Median()
        {
            int length = 0;

            if (!Int32.TryParse(ui.Input("Number of values:", new string[] { "3", "4", "5" }), out length))
            {
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
                return;
            }

            IEnumerable<double> values = new double[length];

            values = values.Select(v => GetRandomDecimal(5));

            ui.Output($"The median of {string.Join(" and ", values)} is " + values.Median());

        }

        [UIOptionAttribute]
        internal void METHEXT_Linq_TakeEvery()
        {
            string input = ui.Input("Text:", new string[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });

            if (!Int32.TryParse(ui.Input("Every:", new string[] { "2", "4", "6" }), out int every))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else if (!Int32.TryParse(ui.Input("Skip initial:", new string[] { "1", "2", "3" }), out int skipInitial))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else
            {
                IEnumerable<char> filtered = input.ToCharArray().TakeEvery(every, skipInitial);
                ui.Output(System.String.Join(", ", filtered), "Result");
            }
        }

        public void SetUI(IUI ui)
        {
            this.ui = ui;
        }

        private double GetRandomDecimal(int maxValue)
        {
            Random r = new Random();
            int rInt = r.Next(0, maxValue * 100);

            return (double)rInt / 100;
        }
    }
}
