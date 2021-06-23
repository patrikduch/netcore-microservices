using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System;

namespace Catalog.Application.Features.Queries.Products.GetSingleProduct
{
    /// <summary>
    /// CQRS query object for fetching single product item.
    /// </summary>
    public class GetProductQuery : IRequest<Result<ProductVm>>
    {
        /// <summary>
        /// Gets or sets string identifier of particular product. 
        /// </summary>
        public Guid ProductId { get; set; }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }

    }
}
