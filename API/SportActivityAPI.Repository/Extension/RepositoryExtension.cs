using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Repository.UnitsOfWork;

namespace SportActivityAPI.Repository.Extension
{
    public static class RepositoryExtension
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SporttrackerContext>(options =>
                           options.UseMySql(config.GetConnectionString("DefaultConnection"), ServerVersion.Parse("5.7.35-mysql")));
        }

        public static void ConfigureRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
