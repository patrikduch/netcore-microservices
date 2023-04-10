//---------------------------------------------------------------------------
// <copyright file="IProjectRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.Application.ProjectName.Interfaces.Persistence.Repositories;

using Domain.Entities;
using NetMicroservices.SqlWrapper.Nuget;

/// <summary>
/// Data repository contract of <seealso cref="ProjectDetailEntity"/> entity.
/// </summary>
public interface IProjectRepository : IAsyncRepository<ProjectDetailEntity>
{
}
