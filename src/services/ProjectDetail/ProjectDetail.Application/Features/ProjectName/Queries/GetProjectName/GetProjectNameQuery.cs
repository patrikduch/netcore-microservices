using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System.Collections.Generic;

namespace ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName
{
    /// <summary>
    /// CQRS query for fetching information about current project.
    /// </summary>
    public class GetProjectNameQuery:  IRequest<Result<ProjectVm>>
    {
    }
}
