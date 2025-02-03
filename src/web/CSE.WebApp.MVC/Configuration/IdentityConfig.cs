using Microsoft.AspNetCore.Authentication.Cookies;

namespace CSE.WebApp.MVC.Configuration;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/acesso-negado";
            });

        return builder;
    }

    public static WebApplication UseIdentityConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }   
}
