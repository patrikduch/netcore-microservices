//---------------------------------------------------------------------------
// <copyright file="ProductContext.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Persistence.EntityConfigurations;

/// <summary>
/// <seealso cref="DbContext"/>  configuration for  <seealso cref="ProductEntity"/>.
/// </summary>
public class ProductContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductContext"/>.
    /// </summary>
    /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets collection of products.
    /// </summary>
    public DbSet<ProductEntity>? Products { get; set; }

    /// <summary>
    /// Gets or sets collection of product categories.
    /// </summary>
    public DbSet<CategoryEntity>? Categories { get; set; }

    /// <summary>
    /// Gets or sets collection of product types.
    /// </summary>
    public DbSet<ProductTypeEntity>? ProductTypes { get; set; }


    /// <summary>
    /// Adding configuration to the <seealso cref="ProductContext"/>.
    /// </summary>
    /// <param name="modelBuilder"><seealso cref="ModelBuilder"/> object for extending current <seealso cref="ProductContext"/> object.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductVariantConfiguration());
    }
}