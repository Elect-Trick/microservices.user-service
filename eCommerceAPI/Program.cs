using eCommerceAPI.Middleware;
using eCommerceInfrastructure.DependencyInjection;
using eCommerceCore.DependencyInjection;
using eCommerceCore.Mapper;
using FluentValidation;
using eCommerceCore.Validator;

var builder = WebApplication.CreateBuilder(args);
//test
//Inject infrastructure services.
builder.Services.AddInfrastructure();
builder.Services.AddCoreLayer();
builder.Services.AddAutoMapper(cfg => {
cfg.AddMaps(typeof(ApplicationUserMappingProfile).Assembly);
    });

builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();

//Add Controllers

builder.Services.AddControllers();
//Swagger config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.Run();
