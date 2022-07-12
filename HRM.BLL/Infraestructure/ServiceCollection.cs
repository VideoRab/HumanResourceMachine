using HRM.BLL.Interfaces;
using HRM.BLL.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHumanService, HumanService>();

            return services;
        }
    }
}
