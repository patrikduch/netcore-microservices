using MediatR;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Commands.DeleteOrder
{
    /// <summary>
    /// Structure for CQRS deletion command of particular <seealso cref="Order"/> entity.
    /// </summary>
    public class DeleteOrderCommand : IRequest
    {
        /// <summary>
        /// Gets or sets numeric identifier for Order entity deletion.
        /// </summary>
        public int Id { get; set; }
    }
}
