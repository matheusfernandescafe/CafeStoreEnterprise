using CSE.WebApp.MVC.Extensions;
using CSE.WebApp.MVC.Services;

namespace CSE.WebApp.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUser, AspNetUser>();

        return builder;
    }
}
