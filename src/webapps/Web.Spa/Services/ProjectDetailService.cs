using AspnetCore.React.Redux.template.Models;
using WebSpa.TypeScript.Infrastructure;

namespace AspnetCore.React.Redux.template.Services
{
    /// <summary>
    /// Service for project detail management.
    /// </summary>
    public class ProjectDetailService : ServiceBase
    {    
        /// <summary>
        /// Get basic information about project
        /// </summary>
        /// <returns>Instance of ProjectDetailModel</returns>
        public Result<ProjectDetailModel> GetProjectDetail()
        {
            var data = new ProjectDetailModel
            {
                Id = 1,
                Name = "E-commerce template"
            };

            return Ok(data);
        }
    }
}
