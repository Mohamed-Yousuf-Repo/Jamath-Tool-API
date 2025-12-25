using Administration.Data.IRepositories;
using Administration.Data.Repositories;

namespace Administration.API.DependancyInjections
{
    public static class RepositoriesDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IAccountRepository, AccountRepository>();
            return repositories;
        }
    }
}
