//---------------------------------------------------------------------------
// <copyright file="IProjectRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.Application.Contracts.Persistence;

using NetMicroservices.SqlWrapper.Nuget;
using ProjectDetail.Domain;

/// <summary>
/// Data repository contract of <seealso cref="ProjectDetail"/> entity.
/// </summary>
public interface IProjectRepository : IAsyncRepository<ProjectDetail>
{
}
