using Microsoft.Extensions.DependencyInjection;

namespace Alkomentor.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddTransient<IAccountService, AccountService>()
                    .AddTransient<IProfileService, ProfileService>();
}
