using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.Contracts.Persistence;
using ProjectDetail.Domain;
using ProjectDetail.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDetail.Persistence.Repositories
{
    public class ProjectRepository : RepositoryBase<Project, ProjectContext>, IProjectRepository
    {

        private readonly ProjectContext _projectContext;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectRepository"/>.
        /// </summary>
        /// <param name="projectContext">Order <seealso cref="DbContext"/> dependency object.</param>
        public ProjectRepository(ProjectContext orderContext) : base(orderContext)
        {
            _projectContext = orderContext;
        }

    }
}
