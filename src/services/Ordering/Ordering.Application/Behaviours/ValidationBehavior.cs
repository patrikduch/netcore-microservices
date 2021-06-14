using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationException;

namespace Ordering.Application.Behaviours
{
    /// <summary>
    /// Validation executor that will check all registered validations.
    /// </summary>
    /// <typeparam name="TRequest">Current request.</typeparam>
    /// <typeparam name="TResponse">Response object for particular request.</typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            if (_validators.Any()) {
                var ctx = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(ctx)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();


                if (failures.Count != 0)
                {
                    throw new  ValidationException(failures);
                }
            }

            return await next();
        }
    }

}
