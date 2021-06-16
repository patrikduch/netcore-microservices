using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using System;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    /// <summary>
    /// Service for sending e-mails.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Execution of e-mail sending functionality.
        /// </summary>
        /// <param name="email">Setzo of new incoming e-mail</param>
        /// <returns></returns>
        public Task<bool> SendEmailAsync(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
