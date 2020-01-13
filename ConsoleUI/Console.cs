using AdventureWorks.Interfaces;
using AdventureWorks.UI;
using AdventureWorks.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Console : IUI
    {
        private bool running = true;

        public void Run(IUI ui, Dictionary<string, UiOption> uiOptions)
        {
            // Add the Quit option to console menu
            uiOptions.Add("q", new UiOption { Action = () => running = false, Text = "Quit" });

            while (running)
                HandleUserInteraction(ui, uiOptions);
        }

        private static void HandleUserInteraction(IUI ui, Dictionary<string, UiOption> uiOptions)
        {
            UiOption uiOption = null;

            ui.Output(new string('-', 40));

            foreach (KeyValuePair<string, UiOption> option in uiOptions)
                ui.Output($"({option.Key}) - {option.Value.Text}");

            string input = ui.Input("Select an option:", null);

            if (!string.IsNullOrEmpty(input) && uiOptions.TryGetValue(input, out uiOption))
                uiOption.Action();
            else
                ui.Output("Option does not exist");
        }

        public string Input(string message, string[] choices)
        {
            System.Console.WriteLine(message);
            return System.Console.ReadLine();
        }

        public void Output(string text, string title)
        {
            string[] lines = text.Split(new char[] {Constant.SEPARATOR});

            foreach(string line in lines)
                System.Console.WriteLine(line);
        }
    }
}
