//---------------------------------------------------------------------------
// <copyright file="GetProductQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProduct;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Dtos;

/// <summary>
/// CQRS query for fetching particular product.
/// </summary>
public class GetProductQuery : IRequest<ServiceResponse<ProductDetailDto>>
{
    public Guid ProductId { get; set; }
}
