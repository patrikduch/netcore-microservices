// <copyright file="IProductService.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.ApiServices;

using Models;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// Defines the contract for a product service.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Asynchronously retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains a ServiceResponse object that encapsulates 
    /// the status of the service call and the product data.
    /// </returns>
    Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id);
}