using eCommerceCore.ServiceContracts;
using eCommerceCore.Services;
using eCommerceCore.Validator;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using eCommerceCore.DTO;

namespace eCommerceCore.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {//Allows us to inject services to the core dependency injection containe.
     //TODO

        services.AddTransient<IUserService, UserService>();
        services.AddScoped<IValidator<LoginDTO>, LoginValidator>();

        return services;
    }
}
