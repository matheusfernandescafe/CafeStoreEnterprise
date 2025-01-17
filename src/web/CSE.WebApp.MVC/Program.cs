using CSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;
builder.Configuration
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var services = builder.Services;
services.AddIdentityConfiguration();
services.AddMvcConfiguration(builder.Configuration);

var app = builder.Build();

app.UseMvcConfiguration(app.Environment);

app.Run();
