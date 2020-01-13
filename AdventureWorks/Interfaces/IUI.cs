using AdventureWorks.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Interfaces
{
    public interface IUI
    {
        void Run(IUI ui, Dictionary<string, UiOption> uiOptions);
        string Input(string message, string[] choices);
        void Output(string text, string title = "");
    }
}
