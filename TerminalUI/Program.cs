using System;
using Microsoft.Extensions.DependencyInjection;

namespace TerminalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = BuildServiceCollection();
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                var r = sp.GetService<AdventureWorks.UI.Runner>();
                r.Run();
            }
        }

        private static IServiceCollection BuildServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.RegisterAppComponents();

            return services;
        }
    }
}
