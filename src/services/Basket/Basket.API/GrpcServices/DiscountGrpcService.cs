using Discount.Grpc.Protos;
using System;
using Grpc.Net.Client;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Basket.API.GrpcServices
{
    /// <summary>
    /// Encapsulation of generated gRPC proto service.
    /// </summary>
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="DiscountGrpcService"/> WebAPI controller.
        /// </summary>
        /// <param name="discountProtoServiceClient"></param>
        public DiscountGrpcService(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            var channel = GrpcChannel.ForAddress(_configuration["GrpcSettings:DiscountUrl"], new GrpcChannelOptions
            {
                LoggerFactory = loggerFactory
            });

            _discountProtoServiceClient = new DiscountProtoService.DiscountProtoServiceClient(channel) ?? throw new ArgumentNullException(nameof(channel));
        }

        /// <summary>
        /// Get discount for particular product from Discount.Grpc service.
        /// </summary>
        /// <param name="productName">Name of particular product.</param>
        /// <returns></returns>
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
        }

    }
}
