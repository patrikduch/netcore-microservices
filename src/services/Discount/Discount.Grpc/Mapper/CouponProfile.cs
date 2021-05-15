using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    /// <summary>
    /// Automapper profile for discount coupon object.
    /// </summary>
    public class CouponProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="CouponProfile"/> class.
        /// </summary>
        public CouponProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
