using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureWorks.Helper
{
    public static class Common
    {
        public static void Print(Interfaces.IUI ui, IEnumerable<string> enumerable)
        {
            string text = string.Join(Constant.SEPARATOR, enumerable.ToArray());

            ui.Output(text, "Result");
        }
    }
}
