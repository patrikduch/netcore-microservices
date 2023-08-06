//-----------------------------------------------------------------------------------
// <copyright file="Config.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace IdentityAuth;

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

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
            // List of microservices
            new ApiResource
            {
                Name = "productAPI",
                DisplayName = "Product API",
                Scopes = { "productAPI", "openid" }
            }

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

                AllowedScopes = {
                    "productAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email}
            },

            new Client
            {
                ClientId = "mvc_client",
                ClientName = "MVC Web App",
                //AllowedGrantTypes = GrantTypes.Code, // Authorization Code Flow
                AllowedGrantTypes = GrantTypes.Hybrid,
                AllowRememberConsent = false,

                RequirePkce = true, // Make sure PKCE is required
                RequireClientSecret = true,

                RedirectUris = { "https://webmvc.shopwinner.org/signin-oidc", "https://localhost:1000/signin-oidc", "https://localhost:1000/your-callback-path" },
                PostLogoutRedirectUris = { "https://webmvc.shopwinner.org/signout-callback-oidc", "https://localhost:1000/signout-callback-oidc" },

                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "productAPI"
                },

                AllowedCorsOrigins = { "https://webmvc.shopwinner.org" }
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