using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using AdventureWorks.Methods;
using System.Linq;

namespace AdventureWorks.UI
{
    public class Runner
    {
        private Dictionary<string, UiOption> uiOptions = new Dictionary<string, UiOption>();
        private Interfaces.IUI ui;
        private readonly BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        // This class implements the console user interface of the application.
        public Runner(Interfaces.IUI ui)
        {
            this.ui = ui;

            string nspace = "AdventureWorks.Methods";
            int iMethodCount = 0;

            var types = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.IsClass && t.Namespace == nspace && t.Name.Substring(0, 3) != "<>c");

            types.ToList().ForEach(t => 
                {
                    Dictionary<string, UiOption> uiOptionsType = GetUIOptionsOfType(t, iMethodCount);
                    uiOptions = uiOptions.Select(u => u).Concat(uiOptionsType).ToDictionary(w => w.Key, w => w.Value);
                    iMethodCount += uiOptions.Count;     
                });
        }

        private Dictionary<string, UiOption> GetUIOptionsOfType(Type type, int iMethodsCount)
        {
            IEnumerable<MethodInfo> methodInfos = GetMethodsWithAttribute(type, typeof(UIOptionAttribute));
            dynamic methodClass = Activator.CreateInstance(type);
            methodClass.SetUI(ui);

            Dictionary<string, UiOption> uiOptionsType = 
                methodInfos.Select((curMethod, index) =>
                {
                    var option = new UiOption
                    {
                        Action = () => curMethod.Invoke(methodClass, null),
                        Text = curMethod.Name.Replace("_", ": ")
                    };
                    return new { Index = (index + 1 + iMethodsCount).ToString(), Option = option };

                }).ToDictionary(key => key.Index, elem => elem.Option);

            return uiOptionsType;
        }

        public void Run()
        {
            ui.Run(ui, uiOptions);
        }

        public IEnumerable<MethodInfo> GetMethodsWithAttribute(Type classType, Type attributeType)
        {
            return classType.GetMethods(bindingFlags).Where(
                methodInfo => methodInfo.GetCustomAttributes(attributeType, true).Length > 0);
        }
    }
}
