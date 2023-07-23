using IdentityModel.Client;

namespace Web.Mvc.ApiServices;

using Models;
using NetMicroservices.ServiceConfig.Nuget;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }


    public async Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id)
    {
        var apiGwClient = _clientFactory.CreateClient("api-gw");
        var identityServerClient = _clientFactory.CreateClient("identity-server");

        // Get token from IdentityServer, of course we should provide the IS configuration like address etc.
        // Send request to a protected API
        // Deserialize the object 

        var apiClientCredentials = new ClientCredentialsTokenRequest
        {
            Address =  identityServerClient.BaseAddress+"connect/token",
            ClientId = "productClient",
            ClientSecret = "secret",

            // This is the scope our protected API
            Scope = "productAPI",
        };

        // create a new HttpClient to talk to our IdentityServer

        var discoveryDocument = await identityServerClient.GetDiscoveryDocumentAsync(identityServerClient.BaseAddress.ToString());

        if (discoveryDocument.IsError)
        {
            return null; // throw  500 error
        }

        //  Authenticates and get an access token from IdentityServer
        var tokenResponse = await identityServerClient.RequestClientCredentialsTokenAsync(apiClientCredentials);

        if (tokenResponse.IsError)
        {
            return null;
        }


        // Send request to a protected API

        // Another HttpClient for talking now with our protected API

        //  Set the access token in the request Authorization Bearer <token>
        apiGwClient.SetBearerToken(tokenResponse.AccessToken);

        // Send request to our protected API
        var testResponse = await apiGwClient.GetAsync("/products");
        testResponse.EnsureSuccessStatusCode();


        if (testResponse.IsSuccessStatusCode)
        {
            var productData = await testResponse.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            return productData;
        }
        else
        {
            throw new Exception($"Error: {testResponse.StatusCode}");
        }
    }
}
