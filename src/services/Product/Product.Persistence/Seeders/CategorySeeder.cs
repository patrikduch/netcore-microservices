//-----------------------------------------------------------------------------------
// <copyright file="CategorySeeder.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------

using Product.Domain.Entities;
using Product.Persistence.Contexts;

namespace Product.Persistence.Seeders;

/// <summary>
/// Seeding example categories data.
/// </summary>
public class CategorySeeder
{
    private readonly ProductContext _productContext;

    public CategorySeeder(ProductContext productContext)
    {
        _productContext = productContext;
    }

    /// <summary>
    /// Functionality to seed example product's data.
    /// </summary>
    public void Seed()
    {
        if (_productContext.Categories is null || !_productContext.Categories.Any())
        {

            List<CategoryEntity> categories = new()
            {
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Books",
                    Url = "books"
                },

                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Movies",
                    Url = "movies"
                },

                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Video Games",
                    Url = "video-games"
                }
            };

            _productContext.Categories.AddRange(categories);
            _productContext.SaveChanges();
        }
    }

}
