namespace CSE.Cliente.API.Configuration;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder AddDependecyInjectionConfig(this WebApplicationBuilder builder)
    {
        //builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

        return builder;
    }
}
