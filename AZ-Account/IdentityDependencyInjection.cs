using Account.Persistence;
using Account.Persistence.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AZ_Account;
public static class IdentityDependencyInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {


        // Add ASP.NET Core Identity
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AccountContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
         .AddAspNetIdentity<ApplicationUser>()
         .AddInMemoryClients(Config.Clients)
         .AddInMemoryApiScopes(Config.ApiScopes)
         .AddInMemoryApiResources(Config.ApiResources)
         .AddInMemoryIdentityResources(Config.IdentityResources)
         .AddDeveloperSigningCredential();

        // JWT Auth for API
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "http://localhost:7171";
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                NameClaimType = "name",
                RoleClaimType = "role"
            };
        });


        // Authorization
        services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "account.api");
            });
        });

        return services;
    }
}

