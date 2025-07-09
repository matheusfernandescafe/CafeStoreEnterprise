using Microsoft.OpenApi.Models;

namespace CSE.Catalogo.API.Configuration;

public static class SwaggerConfig
{
    public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "CafeStore Enterprise Identity API",
                Description = "API desenvolvida durante o curso \"ASP.NET Core Enterprise Applications\" da plataforma Desenvolvedor.io. Este repositório demonstra práticas avançadas na construção de aplicações empresariais com o ASP.NET Core.",
                Contact = new OpenApiContact() { Name = "Matheus Fernandes", Email = "matheusfernandesofc@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });

        return builder;
    }

    public static WebApplication UseSwaggerConfig(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
