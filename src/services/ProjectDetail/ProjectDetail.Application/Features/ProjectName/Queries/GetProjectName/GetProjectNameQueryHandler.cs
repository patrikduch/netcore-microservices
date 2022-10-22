//---------------------------------------------------------------------------
// <copyright file="GetProjectNameQueryHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName;

using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using ProjectDetail.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ProjectDetail.Domain;
using ProjectDetail.Application.Dtos;

/// <summary>
/// CQRS query handler class for fetching project name.
/// </summary>
public class GetProjectNameQueryHandler : IRequestHandler<GetProjectNameQuery, Result<ProjectDetailDto>>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProjectNameQueryHandler"/>.
    /// </summary>
    /// <param name="mapper">Domain to Application object mapper dependency.</param>
    /// <param name="projectRepository">Data repository for <seealso cref="ProjectDetail"/> entity.</param>
    public GetProjectNameQueryHandler(IMapper mapper, IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Handler functionality for fetching project name from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancelation token object dependency.</param>
    /// <returns>Asynchronous task with <seealso cref="ProjectDetailDto"/> object.</returns>
    public async Task<Result<ProjectDetailDto>> Handle(GetProjectNameQuery request, CancellationToken cancellationToken)
    {
        var entity = await _projectRepository.GetFirstAsync();

        return new Result<ProjectDetailDto>(_mapper.Map<ProjectDetailDto>(entity));
    }
}
