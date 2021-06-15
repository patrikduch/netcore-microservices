using Customer.Domain;
using NetMicroservices.SqlWrapper.Nuget;

namespace Customer.Application.Contracts
{
    /// <summary>
    ///  Data repository contract of <seealso cref="Person"/> entity.
    /// </summary>
    public interface IPersonRepository : IAsyncRepository<Person>
    {}
}
