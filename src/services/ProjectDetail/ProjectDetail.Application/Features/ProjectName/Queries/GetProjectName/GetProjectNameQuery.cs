//---------------------------------------------------------------------------
// <copyright file="GetProjectNameQuery.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using ProjectDetail.Application.ProjectName.Dtos;

/// <summary>
/// CQRS query for fetching information about current project.
/// </summary>
public class GetProjectNameQuery : IRequest<Result<ProjectDetailDto>>
{
}
