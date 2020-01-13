using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public static class WebApiServiceProvider
    {
        public static IServiceCollection RegisterAppComponents(this IServiceCollection collection)
        {
            collection
                .AddScoped<AdventureWorks.Interfaces.IUI, Console>()
                .AddScoped<AdventureWorks.UI.Runner>();

            return collection;
        }
    }
}
