﻿using System.Security.Claims;
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
            new ApiResource
            {
                Name = "productAPI",
                DisplayName = "Product API",
                Scopes = { "productAPI" }
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

                AllowedScopes = {"productAPI"}
            },

            new Client
            {
                ClientId = "mvc_client",
                ClientName = "MVC Web App",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,

                RequirePkce = true, // Make sure PKCE is required
                RequireClientSecret = true,

                RedirectUris = { "https://webmvc.shopwinner.org/signin-oidc", "https://localhost:1000/signin-oidc", "https://localhost:1000/your-callback-path" },
                PostLogoutRedirectUris = { "https://webmvc.shopwinner.org/signout-callback-oidc", "https://localhost:1000/signout-callback-oidc" },

                //ProtocolType = "https",

                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
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