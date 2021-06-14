using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Persistence.Contexts
{
    /// <summary>
    /// Data seed functionality for <seealso cref="Order"/> entity.
    /// </summary>
    public class OrderContextSeed
    {
        /// <summary>
        /// Seed execution of <seealso cref="Order"/> entity.
        /// </summary>
        /// <param name="orderContext">Order DbContext dependency.</param>
        /// <param name="logger">Logger functionality dependency.</param>
        /// <returns>Asynchronous task.</returns>
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        /// <summary>
        /// Preconfigured data for db initialization.
        /// </summary>
        /// <returns>Collection of Order entities.</returns>
        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {Username = "patrikduch", FirstName = "Patrik", LastName = "Duch", EmailAddress = "duchpatrik@icloud.com", AddressLine = "Ostravská 1619/48", Country = "ČR", TotalPrice = 350 }
            };
        }
    }
}
