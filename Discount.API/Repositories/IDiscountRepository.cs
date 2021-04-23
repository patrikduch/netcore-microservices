using Discount.API.Entities;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    /// <summary>
    /// Contract for data repository <seealso cref="DiscountRepository"/>.
    /// </summary>
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);

        Task<bool> CreateDiscount(Coupon coupon);

        Task<bool> UpdateDiscount(Coupon coupon);

        Task<bool> DeleteDiscount(string productName);
    }
}
