﻿//------------------------------------------------------------------------------------
// <copyright file="ProjectContext.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence.Contexts;

using Domain.Entities;
using EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// <seealso cref="DbContext"/>  configuration for  <seealso cref="ProjectDetailEntity"/> entity.
/// </summary>
public class ProjectDetailContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProjectDetailContext"/>.
    /// </summary>
    /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
    public ProjectDetailContext(DbContextOptions<ProjectDetailContext> options) : base(options)
    {
    }

    /// <summary>
    /// Set of <seealso cref="ProjectDetailEntity"/> entities.
    /// </summary>
    public DbSet<ProjectDetailEntity> Projects { get; set; }


    /// <summary>
    /// Adding configuration rules to the <seealso cref="ProjectDetailContext"/>.
    /// </summary>
    /// <param name="modelBuilder"><seealso cref="ModelBuilder"/> object for extending current <seealso cref="ProjectDetailContext"/> object.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectDetailConfiguration());
    }

    /// <summary>
    /// Custom implementation of save functionality for <seealso cref="OrderContext"/>.
    /// </summary>
    /// <param name="cancellationToken">Cancelation object.</param>
    /// <returns>Asynchronous task with integer result, that represents successfull or unsuccessfull operation.</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = "patrikduch";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "patrikduch";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
