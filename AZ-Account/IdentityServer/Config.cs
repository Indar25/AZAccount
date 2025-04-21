// AZ_Account/IdentityServer/Config.cs
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

public static class Config
{
    public static IEnumerable<Client> Clients => new[]
    {
        new Client
        {
            ClientId = "gateway-client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = {
                        "account.api",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
            },
            RedirectUris = { "https://localhost:7171/signin-oidc" },
            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:7171/signout-callback-oidc" },
            AllowOfflineAccess = true,
            AccessTokenLifetime = 3600
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new[] { new ApiScope("account.api", "Account API") };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("account.api") { Scopes = { "account.api" } }
    };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };
}
