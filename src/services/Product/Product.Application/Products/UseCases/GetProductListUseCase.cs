//---------------------------------------------------------------------------
// <copyright file="GetProductListUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.UseCases;

using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS object for getting list of products.
/// </summary>
public class GetProductListUseCase : IRequest<ServiceResponse<List<ProductDto>>>
{
}
