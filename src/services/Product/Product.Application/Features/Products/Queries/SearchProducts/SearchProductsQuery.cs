//---------------------------------------------------------------------------
// <copyright file="SearchProductsQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.SearchProducts;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Products.Dtos;

/// <summary>
/// CQRS query for searching products by title or description.
/// </summary>
public class SearchProductsQuery : IRequest<ServiceResponse<List<ProductDto>>>
{
    public string SearchText { get; set; } = string.Empty;
}
