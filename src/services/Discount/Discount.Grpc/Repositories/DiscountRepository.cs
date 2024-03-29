﻿using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    /// <summary>
    /// Product's coupons data access. 
    /// </summary>
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection;
        private readonly ILogger<DiscountRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="DiscountRepository"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object that is derived from appsettings.json file.</param>
        public DiscountRepository(IConfiguration configuration, ILogger<DiscountRepository> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _logger = logger;
        }

        /// <summary>
        /// Create a discount for particular product item.
        /// </summary>
        /// <param name="coupon">Information about new coupon.</param>
        /// <returns>Boolean flag encapsulated into async Task.</returns>
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using (_connection)
            {
                var affected =
                await _connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

                if (affected == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Delete discount for particular product.
        /// </summary>
        /// <param name="productName">Name of selected product.</param>
        /// <returns>Boolean flag encapsulated into async Task.</returns>
        public async Task<bool> DeleteDiscount(string productName)
        {
            using (_connection)
            {
                var affected = await _connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
               new { ProductName = productName });

                if (affected == 0)
                    return false;

                return true;

            }
        }

        /// <summary>
        /// Get discount for particular product.
        /// </summary>
        /// <param name="productName">Product name identifier.</param>
        /// <returns>Async result with Coupon item encapsulation.</returns>
        public async Task<Coupon> GetDiscount(string productName)
        {
            try
            {
                using (_connection)
                {
                    var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>
                   ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

                    if (coupon == null)
                        return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

                    return coupon;
                }
            
            } catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Update discount for selected coupon.
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns>Boolean flag encapsulated into async Task.</returns>
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using (_connection)
            {
                var affected = await _connection.ExecuteAsync
                   ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                           new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

                if (affected == 0)
                    return false;

                return true;
            }
        }
    }
}
