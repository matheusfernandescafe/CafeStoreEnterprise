using CSE.Catalogo.API.Data.Repository;
using CSE.Catalogo.API.Models;

namespace CSE.Catalogo.API.Configuration;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder AddDependecyInjectionConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        
        return builder;
    }
}
