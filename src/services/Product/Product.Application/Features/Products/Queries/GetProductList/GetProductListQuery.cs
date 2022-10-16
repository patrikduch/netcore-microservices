//---------------------------------------------------------------------------
// <copyright file="GetProductListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Application.Features.Products.Queries.GetProductList;

using MediatR;
using Product.Application.Dtos;

/// <summary>
/// CQRS query for fetching list of products.
/// </summary>
public class GetProductListQuery : IRequest<List<ProductDto>>
{
}
