//----------------------------------------------------------------------------------------
// <copyright file="GetProductsByCategoryQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------------------
namespace Product.Application.Features.Products.Queries.GetProductsByCategory;

using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using Product.Application.Contracts.Repositories;
using Product.Application.Dtos;
using Product.Domain.Entities;

public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, ServiceResponse<List<ProductDto>>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProductsByCategoryQueryHandler"/>.
    /// </summary>
    /// <param name="productRepository">Data repository for <seealso cref="ProductEntity"/> entity.</param>
    /// <param name="mapper">Domain to Application object mapper dependency.</param>
    public GetProductsByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Fetching list of products by category.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Collection of products filtered by category url.</returns>
    public async Task<ServiceResponse<List<ProductDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync(
            c => c.Category.Url.ToLower()    
                .Equals(request.CategoryUrl.ToLower())
        );

        return new ServiceResponse<List<ProductDto>>
        {
            Data = _mapper.Map<List<ProductDto>>(products)
        };
    }
}
