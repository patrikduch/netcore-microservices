//----------------------------------------------------------------------------------------
// <copyright file="GetProductSuggestionsQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductSuggestions;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Contracts.Readers;
using Product.Application.Contracts.Services;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// CQRS query handler class for fetching list of product's suggestions.
/// </summary>
public class GetProductSuggestionsQueryHandler : IRequestHandler<GetProductSuggestionsQuery, ServiceResponse<List<string>>>
{
    private readonly IProductService _productService;

    public GetProductSuggestionsQueryHandler(IProductService productService)
    {
       _productService= productService;
    }

    public async Task<ServiceResponse<List<string>>> Handle(GetProductSuggestionsQuery request, CancellationToken cancellationToken)
    {
        var suggestionList = await _productService.GetProductSearchSuggestions(request.SearchText);

        return new ServiceResponse<List<string>> { Data = suggestionList };
    }
}
