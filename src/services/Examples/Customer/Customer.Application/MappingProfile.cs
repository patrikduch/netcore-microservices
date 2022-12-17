using AutoMapper;
using Customer.Application.Features.Queries.GetOrderList;
using Customer.Domain;

namespace Customer.Application
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
            CreateMap<Person, PersonVm>().ReverseMap();
        }
    }
}
