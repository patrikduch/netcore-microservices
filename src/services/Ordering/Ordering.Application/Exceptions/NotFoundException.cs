using System;

namespace Ordering.Application.Exceptions
{
    /// <summary>
    /// Custom exception handler when particular item doesn't exists.
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="NotFoundException"/>.
        /// </summary>
        /// <param name="name">Name of the particular validation item.</param>
        /// <param name="key">Key of the particular validation item.</param>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
