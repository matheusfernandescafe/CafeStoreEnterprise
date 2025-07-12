using CSE.Identidade.API.Data;
using CSE.Identidade.API.Extension;
using CSE.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Identity;

namespace CSE.Identidade.API.Configuration;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.AddJwtConfiguration();

        return builder;
    }
}
