// <copyright file="IdentityProfileModel.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright
namespace Web.Mvc.Models.Identity;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a model for identity profile information.
/// </summary>
public class IdentityProfileModel
{
    /// <summary>
    /// Gets or sets the given name of the user.
    /// The JsonPropertyName attribute specifies that this property should be serialized/deserialized with the JSON property name "given_name".
    /// </summary>
    [JsonPropertyName("given_name")]
    public string GivenName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the family name of the user.
    /// The JsonPropertyName attribute specifies that this property should be serialized/deserialized with the JSON property name "family_name".
    /// </summary>
    [JsonPropertyName("family_name")]
    public string FamilyName { get; set; } = string.Empty;
}