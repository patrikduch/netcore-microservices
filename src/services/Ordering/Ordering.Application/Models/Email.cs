namespace Ordering.Application.Models
{
    /// <summary>
    /// Data model for sending emails.
    /// </summary>
    public class Email
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
