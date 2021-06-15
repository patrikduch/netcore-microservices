using Customer.Application.Contracts;
using Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Customer.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<Person> AddAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Person>> GetAllAsync()
        {
            return null;
        }

        public Task<IReadOnlyList<Person>> GetAsync(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Person>> GetAsync(Expression<Func<Person, bool>> predicate = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Person>> GetAsync(Expression<Func<Person, bool>> predicate = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, List<Expression<Func<Person, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
