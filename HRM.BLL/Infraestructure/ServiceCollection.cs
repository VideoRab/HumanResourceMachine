 using HRM.BLL.Interfaces;
using HRM.BLL.Models;
using HRM.BLL.Services;
using HRM.DAL.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericService<Human>, GenericService<Human, HumanEntity>>();
            services.AddScoped<IGenericService<Company>, GenericService<Company, CompanyEntity>>();

            return services;
        }
    }
}
