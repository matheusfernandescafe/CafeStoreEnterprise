using CSE.Catalogo.API.Configuration;
using CSE.WebAPI.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddJwtConfiguration()
    .AddDependecyInjectionConfig()
    .AddCorsConfig()
    .AddDbContextConfig()
    .AddSwaggerConfig();

var app = builder.Build();

app.UseSwaggerConfig()
   .UseCorsConfig()
   .UseApiConfig();

app.Run();
