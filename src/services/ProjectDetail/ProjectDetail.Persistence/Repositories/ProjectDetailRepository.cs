//------------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence.Repositories;

using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.Contracts.Persistence;
using ProjectDetail.Domain;
using ProjectDetail.Persistence.Contexts;

/// <summary>
/// Data repository for management <seealso cref="ProjectDetailEntity"/>.
/// </summary>
public class ProjectDetailRepository : RepositoryBase<ProjectDetailEntity, ProjectDetailContext>, IProjectRepository
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProjectDetailRepository"/>.
    /// </summary>
    /// <param name="projectContext">Order <seealso cref="DbContext"/> dependency object.</param>
    public ProjectDetailRepository(ProjectDetailContext projectContext) : base(projectContext)
    {
    }
}
