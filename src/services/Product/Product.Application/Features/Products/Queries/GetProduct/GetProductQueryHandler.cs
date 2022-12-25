//---------------------------------------------------------------------------
// <copyright file="GetProductQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProduct;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Contracts.Services;
using Product.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// CQRS query handler class for fetching product detail.
/// </summary>
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ServiceResponse<ProductDetailDto>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductQueryHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Fetchiung product detail from database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with <seealso cref="ProductDetailDto"/> object.</returns>
    public async Task<ServiceResponse<ProductDetailDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<ProductDetailDto>();
        var product = await _productService.GetProductDetail(request.ProductId);


        if (product is null)
        {
            response.Success = false;
            response.Message = "Sorry, but this product does not exists.";
        } else
        {
            response.Data = product;
        }

        return response;
    }
}