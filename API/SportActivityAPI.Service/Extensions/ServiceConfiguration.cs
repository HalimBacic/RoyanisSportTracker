using Microsoft.Extensions.DependencyInjection;
using SportActivityAPI.Service.Implementations;
using SportActivityAPI.Service.Interfaces;

namespace SportActivityAPI.Service.Extensions
{
    /// <summary>
    /// Unused in this version of API.
    /// </summary>
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActivityService, ActivityService>();
        }
    }
}
