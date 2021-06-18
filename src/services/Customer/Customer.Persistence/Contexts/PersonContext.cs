using Microsoft.EntityFrameworkCore;
using Customer.Domain;
using System.Threading.Tasks;
using System.Threading;
using System;
using NetMicroservices.SqlWrapper.Nuget;

namespace Customer.Persistence.Contexts
{
    /// <summary>
    /// <seealso cref="PersonContext"/>  configuration for  <seealso cref="Person"/> entity.
    /// </summary>
    public class PersonContext : DbContext
    {
        /// <summary>
        ///  Initializes a new instance of the <seealso cref="PersonContext"/>.
        /// </summary>
        /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }


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
                        entry.Entity.CreatedBy = "patrikduch";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "patrikduch";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
