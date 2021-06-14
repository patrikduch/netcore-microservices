using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Persistence.Contexts
{
    /// <summary>
    /// <seealso cref="DbContext"/>  configuration for  <seealso cref="Order"/> entity.
    /// </summary>
    public class OrderContext : DbContext
    {
        /// <summary>
        ///  Initializes a new instance of the <seealso cref="OrderContext"/>.
        /// </summary>
        /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        /// <summary>
        /// Set of <seealso cref="Order"/> entities.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Custom implementation of save functionality for <seealso cref="OrderContext"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancelation object.</param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "swn";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "swn";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
