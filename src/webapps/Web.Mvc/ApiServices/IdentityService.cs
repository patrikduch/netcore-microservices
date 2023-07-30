// <copyright file="IdentityService.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.ApiServices;

using Constants;
using IdentityModel.Client;
using Models.Identity;
using System.Net.Http;

/// <summary>
/// Handling interactions with the identity server. 
/// It has methods for tasks like retrieving user profile information.
/// </summary>
public class IdentityService : IIdentityService
{
    private readonly IHttpClientFactory _clientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityService"/> class.
    /// </summary>
    /// <param name="clientFactory">The factory to create instances of System.Net.Http.HttpClient</param>
    public IdentityService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    /// <inheritdoc/>
    public async Task<IdentityProfileModel> GetUserProfileInfo(string identityToken, CancellationToken cancellationToken)
    {
        var client = _clientFactory.CreateClient(HttpClientConstants.IdenityServerHttpClientName);

        var request = new HttpRequestMessage(HttpMethod.Get, "/connect/userInfo");

        client.SetToken("Bearer", identityToken);

        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
        {
            var profileData = await response.Content.ReadFromJsonAsync<IdentityProfileModel>();
            return profileData;
        }

        throw new Exception($"Error: {response.StatusCode}");
    }
}
