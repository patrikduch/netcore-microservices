// <copyright file="ApiSettings.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.Config;

/// <summary>
/// Represents the settings necessary for interacting with the API GW.
/// </summary>
public class ApiSettings
{
    /// <summary>
    /// Gets or sets the API Gateway URL. This is the base URL for all the API endpoints.
    /// </summary>
    /// <value>
    /// The API Gateway URL.
    /// </value>
    public string ApiGwUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Identity service URL. This URL is used for authentication and user identity management.
    /// </summary>
    /// <value>
    /// The URL of the Identity service.
    /// </value>
    public string IdentityUrl { get; set; } = string.Empty;
}