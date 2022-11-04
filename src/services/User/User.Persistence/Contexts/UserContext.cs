//---------------------------------------------------------------------------
// <copyright file="UserContext.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
using User.Infrastructure;
using User.Persistence.EntityConfigurations;

/// <summary>
/// <seealso cref="DbContext"/>  configuration for  <seealso cref="UserEntity"/>.
/// </summary>
public class UserContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="UserContext"/>.
    /// </summary>
    /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<UserEntity>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());

        builder.Entity<UserEntity>().HasData(
            UserUtil.CreateUser("patrikduch@test.com", "duch")
        );
    }
}
