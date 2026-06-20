using eCommerceAPI.Middleware;
using eCommerceInfrastructure.DependencyInjection;
using eCommerceCore.DependencyInjection;
using eCommerceCore.Mapper;

var builder = WebApplication.CreateBuilder(args);

//Inject infrastructure services.
builder.Services.AddInfrastructure();
builder.Services.AddCoreLayer();
builder.Services.AddAutoMapper(cfg => {
cfg.AddMaps(typeof(ApplicationUserMappingProfile).Assembly);
    });

//Add Controllers
builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
