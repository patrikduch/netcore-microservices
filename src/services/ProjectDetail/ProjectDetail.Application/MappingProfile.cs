using AutoMapper;
using ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName;
using ProjectDetail.Domain;

namespace ProjectDetail.Application
{
    /// <summary>
    /// Mapping profiles of domain object to the application objects.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="MappingProfile"/> configuration.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Project, ProjectVm>().ReverseMap();
        }
    }
}
