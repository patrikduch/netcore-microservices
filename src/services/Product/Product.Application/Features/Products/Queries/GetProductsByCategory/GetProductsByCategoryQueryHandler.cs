//----------------------------------------------------------------------------------------
// <copyright file="GetProductsByCategoryQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductsByCategory;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Contracts.Services;
using Product.Application.Dtos;

/// <summary>
/// CQRS query handler class for fetching products by category url.
/// </summary>
public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, ServiceResponse<List<ProductDto>>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductsByCategoryQueryHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductsByCategoryQueryHandler(IProductService productService)
    {
        _productService= productService;
    }

    /// <summary>
    /// Fetching list of products by category.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Collection of products filtered by category url.</returns>
    public async Task<ServiceResponse<List<ProductDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProductsByCategory(request.CategoryUrl);

        return new ServiceResponse<List<ProductDto>>
        {
            Data = products
        };
    }
}
