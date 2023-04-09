//---------------------------------------------------------------------------
// <copyright file="SearchProductsUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Handlers;

using Dtos;
using Interfaces.Services;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using UseCases;

/// <summary>
/// CQRS query handler class for searching products.
/// </summary>
public class SearchProductsUseCaseHandler : IRequestHandler<SearchProductsUseCase, ServiceResponse<List<ProductDto>>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="SearchProductsUseCaseHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public SearchProductsUseCaseHandler(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Search products by title and description.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Collection of products filtered search term.</returns>
    public async Task<ServiceResponse<List<ProductDto>>> Handle(SearchProductsUseCase request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<List<ProductDto>>
        {
            Data = await _productService.SearchProducts(request.SearchText)
        };

        return response;
    }
}
