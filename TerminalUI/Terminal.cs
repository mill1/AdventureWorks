using AdventureWorks.Interfaces;
using AdventureWorks.Helper;
using AdventureWorks.UI;
using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace TerminalUI
{
    class Terminal : IUI
    {
        private const int START_X = 3;
        private const int MESSAGE_HEIGHT = 8;
        private const int MESSAGE_MAX_HEIGHT = 30;
        private const int MESSAGE_MAX_ROWS = MESSAGE_MAX_HEIGHT - MESSAGE_HEIGHT;
        private const int MESSAGE_WIDTH_MARGIN = 8;

        IUI ui = null;

        public void Run(IUI ui, Dictionary<string, UiOption> uiOptions)
        {
            this.ui = ui;

            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var win = new Window("Terminal UI " + Constant.APP_NAME)
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(win);

            // Create a menubar
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
                })
            });
            top.Add(menu);

            // Add the controls
            win.Add(new Label(START_X, 2, "Select an option"));

            int height = START_X;
            foreach (KeyValuePair<string, UiOption> option in uiOptions)
            {
                height += 1;
                win.Add(new Button(START_X, height, option.Value.Text) { Clicked = () => { option.Value.Action(); } });
            }

            win.Add(new Label(START_X, height + 2, "Press F9 to activate the menubar"));

            Application.Run();
        }

        string IUI.Input(string message, string[] choices)
        {
            int width = Math.Max(message.Length, String.Join('_', choices).Length) + MESSAGE_WIDTH_MARGIN;

            int msgBoxResult = MessageBox.Query(width, MESSAGE_HEIGHT, Constant.APP_NAME, message, choices);

            return choices[msgBoxResult];
        }

        void IUI.Output(string text, string title)
        {
            string[] lines = text.Split(new char[] { Constant.SEPARATOR }, MESSAGE_MAX_ROWS);

            int indexSeparator = lines[lines.Length - 1].IndexOf(Constant.SEPARATOR);

            if (indexSeparator > 0)  
                lines[lines.Length - 1] = lines[lines.Length - 1].Substring(0, indexSeparator);

            int width = title.Length + MESSAGE_WIDTH_MARGIN;

            foreach (string line in lines)
                width = Math.Max(width, line.Length + MESSAGE_WIDTH_MARGIN);

            string message = "\n" + String.Join("\n", lines);

            if (indexSeparator > 0)
                message += "\n...";

            MessageBox.Query(width, lines.Length + MESSAGE_HEIGHT, title, message, "Ok");
        }

        private bool Quit()
        {
            return ui.Input($"Are you sure you want to quit {Constant.APP_NAME}?", new string[] { "Yes", "No" }) == "Yes";
        }
    }
}
