//---------------------------------------------------------------------------
// <copyright file="ProductContextSeed.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Contexts;

using Microsoft.Extensions.Logging;
using Product.Domain.Entities;

public class ProductContextSeed
{
    /// <summary>
    /// Seed execution of <seealso cref="ProductEntity"/> entity.
    /// </summary>
    /// <param name="projectContext">Project DbContext dependency.</param>
    /// <param name="logger">Logger functionality dependency.</param>
    /// <returns>Asynchronous task.</returns>
    public static async Task SeedAsync(ProductContext productContext, ILogger<ProductContextSeed> logger)
    {
        // TODO - add env file to check if migration should or shouldn't be processed.
        if (productContext is null) return;

        productContext.RemoveRange(productContext.Categories);
        productContext.RemoveRange(productContext.Products);

        await productContext.SaveChangesAsync();

        productContext.Categories.AddRange(GetPreconfiguredCategories());
        await productContext.SaveChangesAsync();

        productContext.Products.AddRange(GetPreconfiguredProjectDetail(productContext));
        await productContext.SaveChangesAsync();

        logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ProductContext).Name);
    }

    /// <summary>
    /// Preconfigured product data for db initialization.
    /// </summary>
    /// <returns>List of products.</returns>
    private static IEnumerable<ProductEntity> GetPreconfiguredProjectDetail(ProductContext productContext)
    {

        var bookCategoryId = productContext.Categories.Where(c => c.Name == "Books").Select(c => c.Id).SingleOrDefault();

        return new List<ProductEntity>
        {
            new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "The Hichhiker's Guide to the Galaxy",
                    Description = "The Hitchhiker's Guide to the Galaxy has become an international multi-media phenomenon; the novels are the most widely distributed, having been translated into more than 30 languages by 2005.[4][5] The first novel, The Hitchhiker's Guide to the Galaxy (1979), has been ranked fourth on the BBC’s The Big Read poll.[6] The sixth novel, And Another Thing, was written by Eoin Colfer with additional unpublished material by Douglas Adams. In 2017, BBC Radio 4 announced a 40th-anniversary celebration with Dirk Maggs, one of the original producers, in charge.[7] The first of six new episodes was broadcast on 8 March 2018.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 9.99M,
                    CategoryId = bookCategoryId
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Ready Player One",
                    Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/Ready_Player_One_cover.jpg/220px-Ready_Player_One_cover.jpg",
                    Price = 7.99M,
                    CategoryId = bookCategoryId
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Nineteen Eighty-Four",
                    Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/220px-1984first.jpg",
                    Price = 6.99M,
                    CategoryId = bookCategoryId
                }
         };
    }

    /// <summary>
    /// Preconfigured product's categories data for db initialization.
    /// </summary>
    /// <returns>List of product's categories.</returns>
    private static IEnumerable<CategoryEntity> GetPreconfiguredCategories()
    {
        return new List<CategoryEntity>    
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
    }
}
