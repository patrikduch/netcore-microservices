using Microsoft.Extensions.Logging;
using ProjectDetail.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDetail.Persistence.Contexts
{
    /// <summary>
    /// Data seed functionality for <seealso cref="Project"/> entity.
    /// </summary>
    public class ProjectContextSeed
    {
        /// <summary>
        /// Seed execution of <seealso cref="Project"/> entity.
        /// </summary>
        /// <param name="projectContext">Project DbContext dependency.</param>
        /// <param name="logger">Logger functionality dependency.</param>
        /// <returns>Asynchronous task.</returns>
        public static async Task SeedAsync(ProjectContext orderContext, ILogger<ProjectContextSeed> logger)
        {
            if (!orderContext.Projects.Any())
            {
                orderContext.Projects.AddRange(GetPreconfiguredProjectDetail());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProjectContext).Name);
            }
        }

        /// <summary>
        /// Preconfigured project detail data for db initialization.
        /// </summary>
        /// <returns>Project detail info.</returns>
        private static IEnumerable<Project> GetPreconfiguredProjectDetail()
        {
            return new List<Project> 
            {
                new Project  {
                Name = "E-Commerce Template",
                CreatedAt = DateTime.Now,
                CreatedBy = "patrikduch",
                LastModifiedBy = "patrikduch",
                LastModifiedDate = DateTime.Now   
             }

            };
          
        }

    }
}
