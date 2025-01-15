using CSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddDbContextConfig()
    .AddIdentityConfig()
    .AddSwaggerConfig();

var app = builder.Build();

app.UseSwaggerConfig()
   .UseCorsConfig()
   .UseApiConfig();

app.Run();
