using Ordering.Application.Models;
using System.Threading.Tasks;

namespace Ordering.Application.Contacts.Infrastructure
{
    /// <summary>
    /// Contract of e-mail service functionality.
    /// </summary>
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
