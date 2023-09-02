using Alkomentor.Infrastructure.Options;
using Alkomentor.Infrastructure.Repositories;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alkomentor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services.AddPostgresDbContext(configuration)
                    .AddRepositories();

    private static IServiceCollection AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresDbOptions>(configuration.GetSection(PostgresDbOptions.SectionName));

        services.AddDbContext<PostgresDbContext>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddTransient<IAccountRepository, AccountRepository>()
                    .AddTransient<IProfileRepository, ProfileRepository>()
                    .AddTransient<IBoozeRepository, BoozeRepository>()
                    .AddTransient<IDrinkRepository, DrinkRepository>()
                    .AddTransient<IStageRepository, StageRepository>();
}
