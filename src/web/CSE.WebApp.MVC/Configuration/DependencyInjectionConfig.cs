using CSE.WebApp.MVC.Services;

namespace CSE.WebApp.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
