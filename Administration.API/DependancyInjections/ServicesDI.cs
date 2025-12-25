using Administration.Domain.IServices;
using Administration.Services.Services;

namespace Administration.API.DependancyInjections
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
