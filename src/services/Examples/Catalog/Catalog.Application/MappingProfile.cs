using AutoMapper;
using Catalog.Application.Features.Queries.Products.GetProducts;
using Catalog.Application.Features.Queries.Products.GetSingleProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application
{
    /// <summary>
    /// Mapping profiles of domain object to the application objects.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="MappingProfile"/> configuration.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Product, ProductsVm>().ReverseMap();
            CreateMap<Product, ProductVm>().ReverseMap();
        }
    }
}
