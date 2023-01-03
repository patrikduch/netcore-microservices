//----------------------------------------------------------------------------------------
// <copyright file="GetProductSuggestionsQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductSuggestions;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS query for fetching list of product suggestions.
/// </summary>
public class GetProductSuggestionsQuery : IRequest<ServiceResponse<List<string>>>
{
    public string SearchText { get; set; } = string.Empty;
}
