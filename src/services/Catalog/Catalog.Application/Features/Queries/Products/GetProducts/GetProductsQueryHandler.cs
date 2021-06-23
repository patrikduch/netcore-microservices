using AutoMapper;
using Catalog.Application.Contracts;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Queries.Products.GetProducts
{
    /// <summary>
    /// CQRS handler for fetching product's list.
    /// </summary>
    public class GetProductsQueryHandler : ServiceBase, IRequestHandler<GetProductsQuery, Result<List<ProductsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="GetProductsQueryHandler"/>.
        /// </summary>
        /// <param name="mapper">Domain to Application object mapper dependency.</param>
        /// <param name="productRepository">Data repository for <seealso cref="Product"/> entity.</param>
        public GetProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// CQRS handler executor for fetching list of products.
        /// </summary>
        /// <param name="request">Incoming request object.</param>
        /// <param name="cancellationToken">Cancelation token dependency object.</param>
        /// <returns></returns>
        public async Task<Result<List<ProductsVm>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return new Result<List<ProductsVm>>(_mapper.Map<List<ProductsVm>>(products));
        }
    }
}
