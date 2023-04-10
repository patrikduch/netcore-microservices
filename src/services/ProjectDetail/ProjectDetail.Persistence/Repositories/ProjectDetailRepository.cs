//------------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence.Repositories;

using Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.ProjectName.Interfaces.Persistence.Repositories;

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
