//---------------------------------------------------------------------------
// <copyright file="FormatExchangeController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Product.Domain.Entities;
using Product.Persistence.EntityConfigurations;

/// <summary>
/// <seealso cref="DbContext"/>  configuration for  <seealso cref="ProductEntity"/>.
/// </summary>
public class ProductContext : DbContext
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductContext"/>.
    /// </summary>
    /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
    public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Gets or sets Collection of Products.
    /// </summary>
    public DbSet<ProductEntity>? Products { get; set; }

    /// <summary>
    /// Adding configuration to the <seealso cref="ProductContext"/>.
    /// </summary>
    /// <param name="modelBuilder"><seealso cref="ModelBuilder"/> object for extending current <seealso cref="ProductContext"/> object.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}