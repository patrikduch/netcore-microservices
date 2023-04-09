//---------------------------------------------------------------------------
// <copyright file="GetProductUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Handlers;

using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Interfaces.Services;
using UseCases;

/// <summary>
/// CQRS handler for fetching product by id.
/// </summary>
public class GetProductUseCaseHandler : IRequestHandler<GetProductUseCase, ServiceResponse<ProductDetailDto>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductUseCaseHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductUseCaseHandler(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Fetching product detail from database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancellation token object dependency.</param>
    /// <returns>Asynchronous task with <seealso cref="ProductDetailDto"/> object.</returns>
    public async Task<ServiceResponse<ProductDetailDto>> Handle(GetProductUseCase request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<ProductDetailDto>();
        var product = await _productService.GetProductDetail(request.ProductId);


        if (product is null)
        {
            response.Success = false;
            response.Message = "Sorry, but this product does not exists.";
        }
        else
        {
            response.Data = product;
        }

        return response;
    }
}
