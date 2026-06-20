using eCommerceCore.RepositoryContracts;
using eCommerceInfrastructure.DbContext;
using eCommerceInfrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerceInfrastructure.DependencyInjection;
   
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {//Allows us to inject services to the IoC container, Infrastructure services often include data access, caching and other low level components.
     //TODO
     services.AddTransient<IUserRepository,UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;


    }
}
