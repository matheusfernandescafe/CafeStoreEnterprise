using CSE.WebApp.MVC.Extensions;
using CSE.WebApp.MVC.Services;
using CSE.WebApp.MVC.Services.Handlers;
using Polly;

namespace CSE.WebApp.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {        
        builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

        builder.Services.AddHttpClient<ICatalogoService, CatalogoService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //.AddTransientHttpErrorPolicy(
            //p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30))
            );

        builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUser, AspNetUser>();

        return builder;
    }

    private static void AddRefit(this WebApplicationBuilder builder)
    {
        var catalogoUrl = builder.Configuration.GetSection("CatalogoUrl").Value ?? "";

        builder.Services.AddHttpClient("Refit", options =>
        {
            options.BaseAddress = new Uri(catalogoUrl);
        })
        .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
        .AddTypedClient(client => Refit.RestService.For<ICatalogoServiceRefit>(client));
    }
}
