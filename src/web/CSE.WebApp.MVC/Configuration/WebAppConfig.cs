using CSE.WebApp.MVC.Extensions;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

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

        var supportedCultures = new[] { new CultureInfo("pt-BR") };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("pt-BR"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        app.UseMiddleware<ExceptionMiddleware>();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Catalogo}/{action=Index}/{id?}");

        return app;
    }
}
