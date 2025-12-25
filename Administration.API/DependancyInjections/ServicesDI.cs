using Administration.Domain.Interfaces.IServices;
using Administration.Services.Services;
using System.Runtime.CompilerServices;

namespace Administration.API.DependancyInjections
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
