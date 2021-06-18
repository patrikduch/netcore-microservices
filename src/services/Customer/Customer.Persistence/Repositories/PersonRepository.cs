using Customer.Application.Contracts;
using Customer.Domain;
using Customer.Persistence.Contexts;
using NetMicroservices.SqlWrapper.Nuget.Repositories;

namespace Customer.Persistence.Repositories
{
    public class PersonRepository : RepositoryBase<Person, PersonContext>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="PersonRepository"/>.
        /// </summary>
        /// <param name="personContext"><seealso cref="Person"/> DbContext dependency object.</param>
        public PersonRepository(PersonContext personContext) : base(personContext)
        {
           
        }
    }
}
