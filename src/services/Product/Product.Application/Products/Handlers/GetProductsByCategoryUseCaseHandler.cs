//---------------------------------------------------------------------------
// <copyright file="GetProductsByCategoryUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Handlers;

using Contracts.Services;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Dtos;
using UseCases;

public class GetProductsByCategoryUseCaseHandler : IRequestHandler<GetProductsByCategoryUseCase, ServiceResponse<List<ProductDto>>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductsByCategoryUseCaseHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductsByCategoryUseCaseHandler(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Fetching list of products by category.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Collection of products filtered by category url.</returns>
    public async Task<ServiceResponse<List<ProductDto>>> Handle(GetProductsByCategoryUseCase request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProductsByCategory(request.CategoryUrl);

        return new ServiceResponse<List<ProductDto>>
        {
            Data = products
        };
    }
}
