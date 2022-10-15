using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.Contracts.Persistence;
using ProjectDetail.Domain;
using ProjectDetail.Persistence.Contexts;

namespace ProjectDetail.Persistence.Repositories
{
    public class ProjectRepository : RepositoryBase<Project, ProjectContext>, IProjectRepository
    {
        private readonly ProjectContext _projectContext;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectRepository"/>.
        /// </summary>
        /// <param name="projectContext">Order <seealso cref="DbContext"/> dependency object.</param>
        public ProjectRepository(ProjectContext projectContext) : base(projectContext)
        {
            _projectContext = projectContext;
        }
    }
}
