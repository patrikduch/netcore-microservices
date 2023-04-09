//---------------------------------------------------------------------------------------
// <copyright file="GetProductsSuggestionsUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------------------
namespace Product.Application.Products.UseCases;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS query for fetching list of product suggestions.
/// </summary>
public class GetProductsSuggestionsUseCase : IRequest<ServiceResponse<List<string>>>
{
    public string SearchText { get; set; } = string.Empty;
}
