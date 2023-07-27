// <copyright file="HttpClientConstants.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.Constants;

/// <summary>
/// Defines a static class that contains constant values related to HttpClient configurations.
/// </summary>
public static class HttpClientConstants
{
    /// <summary>
    /// The name of the HttpClient instance used for making requests to the API Gateway.
    /// </summary>
    public static string ApiGwHttpClientName = "api-gw";

    /// <summary>
    /// The name of the HttpClient instance used for making requests to the Identity Server.
    /// </summary>
    public static string IdenityServerHttpClientName = "identity-server";
}