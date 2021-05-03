namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        /// <summary>
        /// Gets or sets quantity of shoppingcart item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets color of shoppingcart item.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets price of shoppingcart item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets product identifier of shoppingcart item.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets product name  of shoppingcart item.
        /// </summary>
        public string ProductName { get; set; }
    }
}
