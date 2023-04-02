//---------------------------------------------------------------------------
// <copyright file="CategoryRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Repositories;

using Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using Product.Application.Contracts.Repositories;

/// <summary>
/// Data repository for management  <seealso cref="CategoryRepository"/>.
/// </summary>
public class CategoryRepository : RepositoryBase<CategoryEntity, ProductContext>, ICategoryRepository
{
    /// <summary>
    /// Initializes a new instance of the <seealso cref="CategoryRepository"/>.
    /// </summary>
    /// <param name="productContext"><seealso cref="DbContext"/> dependency object.</param>
    public CategoryRepository(ProductContext productContext) : base(productContext)
    {
    }
}
