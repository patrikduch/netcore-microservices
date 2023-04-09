//---------------------------------------------------------------------------
// <copyright file="GetProductsByCategoryUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.UseCases;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Dtos;

/// <summary>
/// CQRS object for getting list of products by provided category url.
/// </summary>
public class GetProductsByCategoryUseCase : IRequest<ServiceResponse<List<ProductDto>>>
{
    public string CategoryUrl { get; set; } = string.Empty;
}
