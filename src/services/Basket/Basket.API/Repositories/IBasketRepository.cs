using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    /// <summary>
    /// Contract for data repository <seealso cref="BasketRepository"/>.
    /// </summary>
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string username);

        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);

        Task DeleteBasket(string username);
    }
}