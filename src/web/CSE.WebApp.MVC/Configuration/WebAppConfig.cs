﻿using CSE.WebApp.MVC.Extensions;

namespace CSE.WebApp.MVC.Configuration;

public static class WebAppConfig
{
    public static WebApplicationBuilder AddMvcConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddControllersWithViews();

        builder.Services.Configure<AppSettings>(configuration);

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

        return builder;
    }

    public static WebApplication UseMvcConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseExceptionHandler("/erro/500");
        app.UseStatusCodePagesWithRedirects("/erro/{0}");
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityConfiguration();

        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
