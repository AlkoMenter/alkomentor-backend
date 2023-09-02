﻿using Alkomentor.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alkomentor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresDbOptions>(configuration.GetSection(PostgresDbOptions.SectionName));

        services.AddDbContext<PostgresDbContext>();
        
        return services;
    }
}
