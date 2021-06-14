using NetMicroservices.SqlWrapper.Nuget;

namespace Customer.Domain
{
    /// <summary>
    /// Domain Customer entity.
    /// </summary>
    public class Customer : EntityBase
    {
        /// <summary>
        /// Gets or sets name of customer.
        /// </summary>
        public string Username { get; set; }
    }
}
