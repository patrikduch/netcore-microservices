namespace IdentityAuth;

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
            }
        };



    public static List<TestUser> TesteUsers =>
        new List<TestUser>
        {

        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

}