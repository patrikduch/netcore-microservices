namespace Ordering.Application.Models
{
    /// <summary>
    /// Global configuration for sending sending emails.
    /// </summary>
    public class EmailSettings
    {
        public string ApiKey { get; set; }

        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
