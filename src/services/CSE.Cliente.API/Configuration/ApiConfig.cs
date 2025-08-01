using CSE.WebAPI.Core.Identidade;

namespace CSE.Clientes.API.Configuration;

public static class ApiConfig
{
    public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
    {
        var environmentName = builder.Environment.EnvironmentName;

        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (builder.Environment.IsDevelopment())
        {
            builder.Configuration.AddUserSecrets<Program>();
        }

        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        return builder;
    }

    public static WebApplication UseApiConfig(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthConfiguration();
        app.MapControllers();

        return app;
    }
}
