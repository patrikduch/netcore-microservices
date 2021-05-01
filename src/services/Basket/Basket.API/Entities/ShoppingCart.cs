using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ShoppingCart"/> WebAPI controller.
        /// </summary>
        /// <param name="username">Username for particular shopping cart.</param>
        public ShoppingCart(string username)
        {
            UserName = username;
        }

        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
