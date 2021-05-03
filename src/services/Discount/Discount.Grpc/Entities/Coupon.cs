namespace Discount.Grpc.Entities
{
    public class Coupon
    {
        /// <summary>
        /// Gets or sets coupon's identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets product's name for particular coupon.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets product's description for particular coupon.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets amounth for particular coupon.
        /// </summary>
        public int Amount { get; set; }
    }
}
