﻿using NetMicroservices.SqlWrapper.Nuget;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    /// <summary>
    /// Data repository contract of <seealso cref="Order"/> entity.
    /// </summary>
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
