using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    /// <summary>
    /// Request class for Order Query object.
    /// </summary>
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public string Username { get; set; }

        /// <summary>
        ///  Initializes a new instance of the <seealso cref="GetOrdersListQuery"/> request query mediator object.
        /// </summary>
        /// <param name="username">Username for particular order.</param>
        public GetOrdersListQuery(string username)
        {
            Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}
