using CSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddEnvironmentConfig();

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();

app.UseMvcConfiguration(app.Environment);

app.Run();
