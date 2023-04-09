//---------------------------------------------------------------------------
// <copyright file="SearchProductsUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.UseCases;

using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS query for searching products by title or description.
/// </summary>
public class SearchProductsUseCase : IRequest<ServiceResponse<List<ProductDto>>>
{
    public string SearchText { get; set; } = string.Empty;
}

