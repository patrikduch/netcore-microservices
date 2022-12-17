using NetMicroservices.SqlWrapper.Nuget;

namespace Customer.Domain
{
    /// <summary>
    /// Domain  customer entity.
    /// </summary>
    public class Person : EntityBase
    {
        /// <summary>
        /// Gets or sets firstname of a customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets lastname of a customer.
        /// </summary>
        public string LastName { get; set; }
    }
}
