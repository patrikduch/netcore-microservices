using NetMicroservices.SqlWrapper.Nuget;
using ProjectDetail.Domain;

namespace ProjectDetail.Application.Contracts.Persistence
{
    /// <summary>
    /// Data repository contract of <seealso cref="Project"/> entity.
    /// </summary>
    public interface IProjectRepository : IAsyncRepository<Project>
    {
    }
}
