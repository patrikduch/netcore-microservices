using Discount.Grpc.Protos;
using System;
using Grpc.Net.Client;
using Grpc.Core;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient, IConfiguration configuration)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            _discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));
            _configuration = configuration;
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

            var httpClient = new HttpClient();
            // The port number(5001) must match the port of the gRPC server.
            httpClient.BaseAddress = new Uri(_configuration["GrpcSettings:DiscountUrl"]);


            var channel = GrpcChannel.ForAddress(httpClient.BaseAddress);
            var client = new DiscountProtoService.DiscountProtoServiceClient(channel);


            return await client.GetDiscountAsync(discountRequest);
        }

    }
}
