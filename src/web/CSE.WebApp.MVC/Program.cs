using CSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddIdentityConfiguration();
builder.AddMvcConfiguration(builder.Configuration);
builder.RegisterServices();

var app = builder.Build();

app.UseMvcConfiguration(app.Environment);

app.Run();