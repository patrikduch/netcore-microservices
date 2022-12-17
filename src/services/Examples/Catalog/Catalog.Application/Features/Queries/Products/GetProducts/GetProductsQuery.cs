using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System.Collections.Generic;

namespace Catalog.Application.Features.Queries.Products.GetProducts
{
    /// <summary>
    /// CQRS query object for fetching list of products.
    /// </summary>
    public class GetProductsQuery : IRequest<Result<List<ProductsVm>>>
    {

    }
}
