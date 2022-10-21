//---------------------------------------------------------------------------
// <copyright file="CategoryRepository.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using Product.Application.Contracts;
using Product.Domain.Entities;
using Product.Persistence.Contexts;

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
