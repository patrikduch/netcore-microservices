//--------------------------------------------------------------------------------------
// <copyright file="GetProjectNameUseCaseHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------------------
namespace ProjectDetail.Application.ProjectName.Handlers;

using AutoMapper;
using Dtos;
using Interfaces.Persistence.Repositories;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System.Threading;
using System.Threading.Tasks;
using UseCases;

/// <summary>
/// CQRS query handler class for fetching project name.
/// </summary>
public class GetProjectNameUseCaseHandler : IRequestHandler<GetProjectNameUseCase, Result<ProjectDetailDto>>
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="GetProjectNameUseCaseHandler"/>.
    /// </summary>
    /// <param name="mapper">Domain to Application object mapper dependency.</param>
    /// <param name="projectRepository">Data repository for <seealso cref="IProjectRepository"/> entity.</param>
    public GetProjectNameUseCaseHandler(IMapper mapper, IProjectRepository projectRepository)
    {
        _mapper = mapper;
        _projectRepository = projectRepository;
    }

    /// <summary>
    /// Handler functionality for fetching project name from the database.
    /// </summary>
    /// <param name="request">Incoming request object.</param>
    /// <param name="cancellationToken">Cancellation token object dependency.</param>
    /// <returns>Asynchronous task with <seealso cref="ProjectDetailDto"/> object.</returns>
    public async Task<Result<ProjectDetailDto>> Handle(GetProjectNameUseCase request, CancellationToken cancellationToken)
    {
        var entity = await _projectRepository.GetFirstAsync();

        return new Result<ProjectDetailDto>(_mapper.Map<ProjectDetailDto>(entity));
    }
}
