namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    /// <summary>
    /// View model class for Order mediator design pattern.
    /// </summary>
    public class OrdersVm
    {
        /// <summary>
        /// Gets or sets order numeric identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of order owner.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets order total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets order owner first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets order owner last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets order owner e-mail address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets order owner address line.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets owner's country name.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets owner's state name.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets zipcode of owner's billing address.
        /// </summary>
        public string ZipCode { get; set; }


        /// <summary>
        /// Gets or sets name of owner credit card.
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// Gets or sets number of owner credit card.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets expiration date of owner credit card.
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Gets or sets card CVV verification code.
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// Gets or sets type of payment method.
        /// </summary>
        public int PaymentMethod { get; set; }
    }
}
