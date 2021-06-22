using ProjectDetail.Domain;

namespace ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName
{
    /// <summary>
    /// View model class for <seealso cref="Project"/> mediator design pattern.
    /// </summary>
    public class ProjectVm
    {
        /// <summary>
        /// Gets or sets numeric identifier for project enttity.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets project name.
        /// </summary>
        public string Name { get; set; }
    }
}
