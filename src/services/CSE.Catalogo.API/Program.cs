using CSE.Catalogo.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddDbContextConfig()
    .AddSwaggerConfig();

var app = builder.Build();

app.UseSwaggerConfig()
   .UseCorsConfig()
   .UseApiConfig();

app.Run();
