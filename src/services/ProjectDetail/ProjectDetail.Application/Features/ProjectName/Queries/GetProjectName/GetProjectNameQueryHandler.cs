
using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using ProjectDetail.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ProjectDetail.Domain;

namespace ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName
{
    /// <summary>
    /// CQRS query handler class for fetching project name.
    /// </summary>
    public class GetProjectNameQueryHandler : IRequestHandler<GetProjectNameQuery, Result<ProjectVm>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="GetProjectNameQueryHandler"/>.
        /// </summary>
        /// <param name="mapper">Domain to Application object mapper dependency.</param>
        /// <param name="projectRepository">Data repository for <seealso cref="Project"/> entity.</param>
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
        /// <returns>Asynchronous task with <seealso cref="ProjectVm"/> object.</returns>
        public async Task<Result<ProjectVm>> Handle(GetProjectNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _projectRepository.GetAsync(p => p.Id == 1);

            return new Result<ProjectVm>(_mapper.Map<ProjectVm>(entity.SingleOrDefault()));
        }
    }

}
