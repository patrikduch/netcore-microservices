using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Persistence.Repositories
{
    /// <summary>
    /// Extended generic repository with additional data access layer method for Order quering and manipulations.
    /// </summary>
    public class OrderRepository : RepositoryBase<Order, OrderContext>, IOrderRepository
    {
        private readonly OrderContext _orderContext;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="OrderRepository"/>.
        /// </summary>
        /// <param name="orderContext">Order <seealso cref="DbContext"/> dependency object.</param>
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
            _orderContext = orderContext;
        }

        /// <summary>
        /// Get orders by owner's username.
        /// </summary>
        /// <param name="userName">Owner's username</param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _orderContext.Orders
                        .Where(o => o.Username == userName).ToListAsync();

            return orderList;
        
        }
    }
}
