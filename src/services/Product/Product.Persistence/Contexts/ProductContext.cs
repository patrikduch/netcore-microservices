//---------------------------------------------------------------------------
// <copyright file="FormatExchangeController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Persistence.EntityConfigurations;

public class ProductContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductContext"/>.
    /// </summary>
    /// <param name="options"> <seealso cref="DbContextOptions{TContext}"/> EFCore context setup.</param>
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity>? Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}
