using AutoMapper;
using Catalog.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Queries.Products.GetSingleProduct
{
    /// <summary>
    /// CQRS handler for fetching particular product item.
    /// </summary>
    public class GetProductQueryHandler : ServiceBase, IRequestHandler<GetProductQuery, Result<ProductVm>>
    {
        private readonly ILogger<GetProductQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="productRepository"></param>
        public GetProductQueryHandler(ILogger<GetProductQueryHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }


        /// <summary>
        /// CQRS executor handler for fetching single product item.
        /// </summary>
        /// <param name="request">Incoming request object.</param>
        /// <param name="cancellationToken">Cancelation token object.</param>
        /// <returns></returns>
        public async Task<Result<ProductVm>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);

            if (product == null)
            {
             _logger.LogError($"Product with id {request.ProductId}, not found");
            }

            return new Result<ProductVm>(_mapper.Map<ProductVm>(product));
        }
    }
}
