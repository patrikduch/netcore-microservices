// <copyright file="IIdentityService.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.ApiServices;

using Models.Identity;

/// <summary>
/// Defines an interface for a service that interacts with the identity server.
/// This interface specifies the operations that an identity service should provide.
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Asynchronously retrieves the profile information of a user from the identity server.
    /// </summary>
    /// <param name="identityToken">The identity token of the user whose profile information is to be retrieved.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation. 
    /// The <see cref="Task{TResult}.Result"/> property returns an <see cref="IdentityProfileModel"/> 
    /// containing the user's profile information.</returns>
    Task<IdentityProfileModel> GetUserProfileInfo(string identityToken, CancellationToken cancellationToken);
}