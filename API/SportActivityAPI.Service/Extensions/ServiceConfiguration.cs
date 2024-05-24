using Microsoft.Extensions.DependencyInjection;
using SportActivityAPI.Service.Implementations;
using SportActivityAPI.Service.Interfaces;

namespace SportActivityAPI.Service.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
