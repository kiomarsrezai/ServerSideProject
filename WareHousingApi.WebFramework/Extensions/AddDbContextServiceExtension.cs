using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WareHousingApi.DataModel;

namespace WareHousingApi.WebApi.Extensions
{
    public static class AddDbContextServiceExtension
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("WareHousingApiConnectionString"));
            });

            return services;
        }
    }
}