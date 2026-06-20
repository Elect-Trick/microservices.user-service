using eCommerceCore.ServiceContracts;
using eCommerceCore.Services;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerceCore.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {//Allows us to inject services to the core dependency injection containe.
     //TODO

        services.AddTransient<IUserService, UserService>();
        return services;
    }
}
