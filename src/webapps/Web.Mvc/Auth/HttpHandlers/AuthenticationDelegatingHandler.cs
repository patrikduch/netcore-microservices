// <copyright file="IAuthenticationDelegatingHandler.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.Auth.HttpHandlers;

using Constants;
using IdentityModel.Client;

public class AuthenticationDelegatingHandler : DelegatingHandler
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ClientCredentialsTokenRequest _tokenRequest;

    public AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest tokenRequest)
    {
        _httpClientFactory = httpClientFactory;
        _tokenRequest = tokenRequest;
    }


    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Getting the token
        var httpClient = _httpClientFactory.CreateClient(HttpClientConstants.IdenityServerHttpClientName);

        var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);

        if (tokenResponse.IsError)
        {
            throw new HttpRequestException("Somethign went wrong while requesting the access token");
        }

        request.SetBearerToken(tokenResponse.AccessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
