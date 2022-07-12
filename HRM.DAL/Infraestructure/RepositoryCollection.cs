using HRM.DAL.Context;
using HRM.DAL.Interfaces.Repository;
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
            services.AddScoped<IHumanRepository, HumanRepository>();

            return services;
        }
    }
}
