using HRM.DAL.Context;
using HRM.DAL.Entities;
using HRM.DAL.Interfaces;
using HRM.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryCollection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HRMContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IGenericRepository<HumanEntity>, GenericRepository<HumanEntity>>();
            services.AddScoped<IGenericRepository<CompanyEntity>, GenericRepository<CompanyEntity>>();

            return services;
        }
    }
}
