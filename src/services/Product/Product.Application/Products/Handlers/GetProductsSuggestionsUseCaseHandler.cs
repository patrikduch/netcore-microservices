//---------------------------------------------------------------------------------------
// <copyright file="GetProductsSuggestionsUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------------------
namespace Product.Application.Products.Handlers;

using Interfaces.Services;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using UseCases;

/// <summary>
/// CQRS query handler class for fetching list of product's suggestions.
/// </summary>
public class GetProductsSuggestionsUseCaseHandler : IRequestHandler<GetProductsSuggestionsUseCase, ServiceResponse<List<string>>>
{
    private readonly IProductService _productService;

    public GetProductsSuggestionsUseCaseHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ServiceResponse<List<string>>> Handle(GetProductsSuggestionsUseCase request, CancellationToken cancellationToken)
    {
        var suggestionList = await _productService.GetProductSearchSuggestions(request.SearchText);

        return new ServiceResponse<List<string>> { Data = suggestionList };
    }
}
