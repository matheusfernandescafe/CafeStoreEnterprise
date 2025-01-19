namespace CSE.WebApp.MVC.Configuration;

public static class EnvirionmentConfig
{
    public static void AddEnvironmentConfig(this WebApplicationBuilder builder)
    {
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
    }
}
