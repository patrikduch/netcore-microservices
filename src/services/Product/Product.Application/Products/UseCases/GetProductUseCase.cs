//---------------------------------------------------------------------------
// <copyright file="GetProductUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.UseCases;

using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS object for getting product by unique identifier.
/// </summary>
public class GetProductUseCase : IRequest<ServiceResponse<ProductDetailDto>>
{
    public Guid ProductId { get; set; }
}
