using Discount.Grpc.Protos;
using System;
using Grpc.Net.Client;
using Grpc.Core;
using System.Net.Http;
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
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="DiscountGrpcService"/> WebAPI controller.
        /// </summary>
        /// <param name="discountProtoServiceClient"></param>
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
            _configuration = configuration;

            _loggerFactory = loggerFactory;
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


            var channel = GrpcChannel.ForAddress(_configuration["GrpcSettings:DiscountUrl"], new GrpcChannelOptions { 
                LoggerFactory = _loggerFactory
            });
            var client = new DiscountProtoService.DiscountProtoServiceClient(channel);


            return await client.GetDiscountAsync(discountRequest);
        }

    }
}
