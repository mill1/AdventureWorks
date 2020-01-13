using Microsoft.Extensions.DependencyInjection;

namespace TerminalUI
{
    public static class TerminalServiceProvider
    {
        public static IServiceCollection RegisterAppComponents(this IServiceCollection collection)
        {
            collection
                .AddScoped<AdventureWorks.Interfaces.IUI, Terminal>()
                .AddScoped<AdventureWorks.UI.Runner>();

            return collection;
        }
    }
}
