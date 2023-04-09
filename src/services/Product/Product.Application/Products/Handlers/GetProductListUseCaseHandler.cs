//---------------------------------------------------------------------------
// <copyright file="GetProductListUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Handlers;

using Contracts.Services;
using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using UseCases;

/// <summary>
/// CQRS handler for fetch list of products.
/// </summary>
public class GetProductListUseCaseHandler: IRequestHandler<GetProductListUseCase, ServiceResponse<List<ProductDto>>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductListUseCaseHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductListUseCaseHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ServiceResponse<List<ProductDto>>> Handle(GetProductListUseCase request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProducts();

        return new ServiceResponse<List<ProductDto>>
        {
            Data = products
        };
    }
}