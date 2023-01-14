//---------------------------------------------------------------------------
// <copyright file="GetProductListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductList;

using MediatR;
using Product.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;
using Product.Application.Contracts.Services;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS query handler class for fetching list of products.
/// </summary>
public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ServiceResponse<List<ProductDto>>>
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductListQueryHandler"/>.
    /// </summary>
    /// <param name="productService"><seealso cref="IProductService"/> dependency object.</param>
    public GetProductListQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Fetchiung list of products from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with collection <seealso cref="ProductDto"/> objects.</returns>
    public async Task<ServiceResponse<List<ProductDto>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProducts();

        return new ServiceResponse<List<ProductDto>>
        {
            Data = products
        };
    }
}
