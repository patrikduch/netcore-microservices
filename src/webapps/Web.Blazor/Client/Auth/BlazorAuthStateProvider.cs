using System.Net.Http.Headers;
using System.Text.Json;

namespace Web.Blazor.Client.Auth;

using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class BlazorAuthStateProvider: AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    
    public BlazorAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }
    
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

        var identity = new ClaimsIdentity();
        
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty((authToken)))
        {
            try
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    authToken.Replace("\"", ""));
            }
            catch (Exception ex)
            {
                await _localStorageService.RemoveItemAsync("authToken");
                identity = new ClaimsIdentity();
            }
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        
        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

    private byte[] ParseBase64WithoutPading(string base64)
    {
        switch (base64.Length % 4) 
        {
            case 2:
                base64 += "=="; break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split(".")[1];
        var jsonBytes = ParseBase64WithoutPading(payload);

        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

        return claims;
    }
}