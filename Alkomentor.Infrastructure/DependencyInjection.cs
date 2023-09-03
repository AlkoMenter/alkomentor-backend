using Alkomentor.Infrastructure.Options;
using Alkomentor.Infrastructure.Repositories;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alkomentor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services.AddPostgresDbContext(configuration)
            .AddHangfire(configuration)
            .AddRepositories();

    private static IServiceCollection AddPostgresDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<PostgresDbOptions>(configuration.GetSection(PostgresDbOptions.SectionName));

        services.AddDbContext<PostgresDbContext>();

        return services;
    }

    private static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(x =>
            x.UsePostgreSqlStorage(configuration.GetConnectionString(HangfireOptions.SectionName) ??
                                   throw new InvalidOperationException("Connection string for Hangfire not found.")));

        services.AddHangfireServer();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<IProfileRepository, ProfileRepository>()
            .AddTransient<IBoozeRepository, BoozeRepository>()
            .AddTransient<IDrinkRepository, DrinkRepository>()
            .AddTransient<IStageRepository, StageRepository>();
}