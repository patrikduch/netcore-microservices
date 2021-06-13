using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
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
            CreateMap<Order, OrdersVm>().ReverseMap();
        }
    }
}
