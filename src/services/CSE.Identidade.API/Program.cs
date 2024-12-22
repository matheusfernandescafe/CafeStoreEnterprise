using CSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddSwaggerConfig()
    .AddDbContextConfig()
    .AddIdentityConfig();

var app = builder.Build();

app.UseSwaggerConfig()
   .UseCorsConfig()
   .UseApiConfig();

app.Run();
