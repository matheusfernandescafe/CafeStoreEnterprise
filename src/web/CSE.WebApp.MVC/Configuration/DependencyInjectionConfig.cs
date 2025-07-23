using CSE.WebApp.MVC.Extensions;
using CSE.WebApp.MVC.Services;
using CSE.WebApp.MVC.Services.Handlers;

namespace CSE.WebApp.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        var catalogoUrl = builder.Configuration.GetSection("CatalogoUrl").Value ?? "";

        builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

        builder.Services.AddHttpClient("Refit", options =>
        {
            options.BaseAddress = new Uri(catalogoUrl);
        })
        .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
        .AddTypedClient(client => Refit.RestService.For<ICatalogoServiceRefit>(client));
        //builder.Services.AddHttpClient<ICatalogoService, CatalogoService>()
        //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUser, AspNetUser>();

        return builder;
    }
}
