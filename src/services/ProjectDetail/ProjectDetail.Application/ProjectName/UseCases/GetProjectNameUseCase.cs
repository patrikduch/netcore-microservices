//---------------------------------------------------------------------------
// <copyright file="GetProjectNameUseCase.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.Application.ProjectName.UseCases;

using Dtos;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

/// <summary>
/// CQRS query for fetching current project name.
/// </summary>
public class GetProjectNameUseCase : IRequest<Result<ProjectDetailDto>>
{

}

