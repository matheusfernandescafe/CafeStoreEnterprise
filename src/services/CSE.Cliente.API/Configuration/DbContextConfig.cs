using CSE.Clientes.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CSE.Clientes.API.Configuration;

public static class DbContextConfig
{
    public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ClienteContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }
}
