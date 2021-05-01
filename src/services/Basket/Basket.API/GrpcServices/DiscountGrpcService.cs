using Discount.Grpc.Protos;
using System;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    /// <summary>
    /// Encapsulation of generated gRPC proto service.
    /// </summary>
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="DiscountGrpcService"/> WebAPI controller.
        /// </summary>
        /// <param name="discountProtoServiceClient">Reference to the generated gRPC <seealso cref="DiscountProtoService.DiscountProtoServiceClient"/> class..</param>
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
        }

        /// <summary>
        /// Get discount for particular product from Discount.Grpc service.
        /// </summary>
        /// <param name="productName">Name of particular product.</param>
        /// <returns></returns>
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
        }

    }
}
