using Customer.Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Persistence.Contexts
{
    /// <summary>
    /// Data seed functionality for <seealso cref="Person"/> entity.
    /// </summary>
    public class PersonContextSeed
    {
        /// <summary>
        /// Seed execution of <seealso cref="Person"/> entity.
        /// </summary>
        /// <param name="orderContext">Order DbContext dependency.</param>
        /// <param name="logger">Logger functionality dependency.</param>
        /// <returns>Asynchronous task.</returns>
        public static async Task SeedAsync(PersonContext personContext, ILogger<PersonContextSeed> logger)
        {
            if (!personContext.Persons.Any())
            {
                personContext.Persons.AddRange(GetPreconfiguredPersons());
                await personContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(PersonContext).Name);
            }
        }

        /// <summary>
        /// Preconfigured data for db initialization.
        /// </summary>
        /// <returns>Collection of Person entities.</returns>
        private static IEnumerable<Person> GetPreconfiguredPersons()
        {
            return new List<Person>
            {
                new Person { FirstName = "Patrik", LastName = "Duch" },
                new Person { FirstName ="Tomáš",   LastName ="Silber" },
                new Person { FirstName = "Petra",  LastName ="Duchová" },
                new Person { FirstName = "Jakub",  LastName = "Mazur"},
                new Person { FirstName ="Josef",   LastName ="Bebčák"},
                new Person { FirstName = "Bogdan", LastName = "Walek"}
            };
        }
    }
}
