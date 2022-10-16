//---------------------------------------------------------------------------
// <copyright file="GetProductListQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Application.Features.Products.Queries.GetProductList;

using AutoMapper;
using MediatR;
using Product.Domain.Entities;
using Product.Application.Contracts;
using Product.Application.Dtos;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// CQRS query handler class for fetching list of products.
/// </summary>
public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductListQueryHandler"/>.
    /// </summary>
    /// <param name="mapper">Domain to Application object mapper dependency.</param>
    /// <param name="productRepository">Data repository for <seealso cref="ProductEntity"/> entity.</param>
    public GetProductListQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handler functionality for fetching list of products from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with collection <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return _mapper.Map<List<ProductDto>>(products);
    }
}
