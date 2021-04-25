using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    /// <summary>
    /// Abstraction of basket's data distributed cache access. 
    /// </summary>
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        /// <summary>
        /// Get basket data from Distrubuted Cache.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _redisCache.GetStringAsync(username);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);

        }

        /// <summary>
        /// Update basket information of selected user.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns>Shopping cart information for particular user.</returns>

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }

        /// <summary>
        /// Delete basket info for particular user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
