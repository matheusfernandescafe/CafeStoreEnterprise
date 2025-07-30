namespace CSE.Cliente.API.Configuration;

public static class CorsConfig
{
    public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Development", builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            options.AddPolicy("Production", builder =>
                builder
                    .WithOrigins("https://localhost:9000")
                    .WithMethods("POST")
                    .AllowAnyHeader());
        });

        return builder;
    }

    public static WebApplication UseCorsConfig(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors("Development");
        }
        else
        {
            app.UseCors("Production");
        }

        return app;
    }
}
