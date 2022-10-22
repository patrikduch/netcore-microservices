//------------------------------------------------------------------------------------
// <copyright file="ProjectContextSeed.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence.Contexts;

using Microsoft.Extensions.Logging;
using ProjectDetail.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Data seed functionality for <seealso cref="ProjectDetail"/> entity.
/// </summary>
public class ProjectContextSeed
{
    /// <summary>
    /// Seed execution of <seealso cref="ProjectDetail"/> entity.
    /// </summary>
    /// <param name="projectContext">Project DbContext dependency.</param>
    /// <param name="logger">Logger functionality dependency.</param>
    /// <returns>Asynchronous task.</returns>
    public static async Task SeedAsync(ProjectContext projectContext, ILogger<ProjectContextSeed> logger)
    {
        var test = projectContext.Database.CanConnect();


        if (!projectContext.Projects.Any())
        {
            projectContext.Projects.AddRange(GetPreconfiguredProjectDetail());
            await projectContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProjectContext).Name);
        }
    }

    /// <summary>
    /// Preconfigured project detail data for db initialization.
    /// </summary>
    /// <returns>Project detail info.</returns>
    private static IEnumerable<ProjectDetail> GetPreconfiguredProjectDetail()
    {
        return new List<ProjectDetail> 
        {
            new ProjectDetail  {
            Name = "E-Commerce Template",
            CreatedAt = DateTime.Now,
            CreatedBy = "patrikduch",
            LastModifiedBy = "patrikduch",
            LastModifiedDate = DateTime.Now   
         }};
    }
}
