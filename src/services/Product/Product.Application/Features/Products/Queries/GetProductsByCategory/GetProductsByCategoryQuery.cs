//----------------------------------------------------------------------------------------
// <copyright file="GetProductsByCategoryQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductsByCategory;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Dtos;

/// <summary>
/// CQRS query for fetching list of products based on category url.
/// </summary>
public class GetProductsByCategoryQuery : IRequest<ServiceResponse<List<ProductDto>>>
{
    public string CategoryUrl { get; set; } = string.Empty;
}
