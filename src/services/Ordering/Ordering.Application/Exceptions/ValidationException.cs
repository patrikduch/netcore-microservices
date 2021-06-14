using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordering.Application.Exceptions
{
    /// <summary>
    /// Custom exception handler when particular item is not valid.
    /// </summary>
    public class ValidationException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ValidationException"/>.
        /// </summary>
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ValidationException"/>.
        /// </summary>
        /// <param name="failures">Coolection of validation failures.</param>
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        /// <summary>
        /// Error of invalid rules for particular item.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }
    }
}
