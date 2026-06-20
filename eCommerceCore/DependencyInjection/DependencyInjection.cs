using eCommerceCore.ServiceContracts;
using eCommerceCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
