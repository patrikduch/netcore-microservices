namespace Web.Blazor.Client.Services.Auth;

using NetMicroservices.ServiceConfig.Nuget;
using Web.Blazor.Shared;
using System.Net.Http.Json;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ServiceResponse<Guid>> Register(UserRegister request)
    {
        var response = await _httpClient.PostAsJsonAsync("/user-register", request);
        
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();

        return result;
    }
}