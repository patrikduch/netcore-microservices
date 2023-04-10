//------------------------------------------------------------------------------------
// <copyright file="ProjectContextSeed.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence.Contexts;

using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Data seed functionality for <seealso cref="ProjectDetailEntity"/> entity.
/// </summary>
public class ProjectDetailContextSeed
{
    /// <summary>
    /// Seed execution of <seealso cref="ProjectDetailEntity"/> entity.
    /// </summary>
    /// <param name="projectContext">Project DbContext dependency.</param>
    /// <param name="logger">Logger functionality dependency.</param>
    /// <returns>Asynchronous task.</returns>
    public static async Task SeedAsync(ProjectDetailContext projectContext, ILogger<ProjectDetailContextSeed> logger)
    {
        //if (!projectContext.Projects.Any())
        // {

        projectContext.Projects.RemoveRange(projectContext.Projects);
        await projectContext.SaveChangesAsync();


        projectContext.Projects.AddRange(GetPreconfiguredProjectDetail());
        await projectContext.SaveChangesAsync();
        logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProjectDetailContext).Name);
        //}
    }

    /// <summary>
    /// Preconfigured project detail data for db initialization.
    /// </summary>
    /// <returns>Project detail info.</returns>
    private static IEnumerable<ProjectDetailEntity> GetPreconfiguredProjectDetail()
    {
        return new List<ProjectDetailEntity> 
        {
            new ProjectDetailEntity  {
            Name = "NetMicroservices project",
            CreatedAt = DateTime.Now,
            CreatedBy = "patrikduch",
            LastModifiedBy = "patrikduch",
            LastModifiedDate = DateTime.Now   
         }};
    }
}
