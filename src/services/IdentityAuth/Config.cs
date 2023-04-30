using System.Security.Claims;
using IdentityModel;

namespace IdentityAuth;

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

/// <summary>
/// IdentityServer configurations
/// </summary>
public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("productAPI", "Product API")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {

        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "productClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())

                },

                AllowedScopes = {"productAPI"}
            },

            new Client
            {
                ClientId = "mvc_client",
                ClientName = "MVC Web App",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>
                {
                    //Environment.GetEnvironmentVariable("IDENTITY_WEB_MVC_URL")+"/signin-oidc"
                   "https://webmvc.shopwinner.org/signin-oidc",
                   "http://webmvc.shopwinner.org/signin-oidc"

                },
                PostLogoutRedirectUris = new List<string>
                {
                    Environment.GetEnvironmentVariable("IDENTITY_WEB_MVC_URL")+"/signout-callback-oidc"
                },

                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };



    public static List<TestUser> TestsUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = Guid.NewGuid().ToString(),
                Username = "duch",
                Password = "duch",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "Patrik"),
                    new Claim(JwtClaimTypes.FamilyName, "Duch")
                }

            }
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

}