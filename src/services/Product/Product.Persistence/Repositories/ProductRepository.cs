//-----------------------------------------------------------------------------------
// <copyright file="ProductRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Persistence.Repositories;

using Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using Product.Application.Contracts.Repositories;

/// <summary>
/// Data repository for management <seealso cref="ProductEntity"/>.
/// </summary>
public class ProductRepository : RepositoryBase<ProductEntity, ProductContext>, IProductRepository
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductRepository"/>.
    /// </summary>
    /// <param name="productContext">Product <seealso cref="DbContext"/> dependency object.</param>
    public ProductRepository(ProductContext productContext) : base(productContext)
    {
    }
}
