using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    /// <summary>
    /// Triggered when there is unhandled validation exception on the Behavior Layer.
    /// </summary>
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<IRequest> _logger;

        /// <summary>
        ///  Initializes a new instance of the <seealso cref="UnhandledExceptionBehavior{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="logger">Logging functionality dependency.</param>
        public UnhandledExceptionBehavior(ILogger<IRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// CQRS handler for all unhandler validation exceptions.
        /// </summary>
        /// <param name="request">Incoming invalidate request.</param>
        /// <param name="cancellationToken">Cancelation token object.</param>
        /// <param name="next">Function for invoking new behavior before passing to the execution handler.</param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        } 
    }
}
