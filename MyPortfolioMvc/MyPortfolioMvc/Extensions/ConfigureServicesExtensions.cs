using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyPortfolioMvc.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static void AddService(this IServiceCollection services, Action<IServiceCollection> configure)
        {
            configure(services);
        }
    }
}
