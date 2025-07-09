using Microsoft.AspNetCore.Identity;
using System.Text;

namespace CSE.Catalogo.API.Configuration;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
    {
        //builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        //        .AddRoles<IdentityRole>()
        //        .AddErrorDescriber<IdentityMensagensPortugues>()
        //        .AddEntityFrameworkStores<ApplicationDbContext>();
        //
        //var JwtSettingsSection = builder.Configuration.GetSection("AppSettings");
        //builder.Services.Configure<AppSettings>(JwtSettingsSection);
        //
        //var jwtSettings = JwtSettingsSection.Get<AppSettings>();
        //var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
        //
        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.RequireHttpsMetadata = true;
        //    options.SaveToken = true;
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidAudience = jwtSettings.ValidoEm,
        //        ValidIssuer = jwtSettings.Emissor
        //    };
        //});

        return builder;
    }
}
