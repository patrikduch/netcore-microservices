//---------------------------------------------------------------------------
// <copyright file="CategoryConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;

/// <summary>
/// Entity configuration for  <seealso cref="CategoryEntity"/>.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id).HasName("id");
        builder.Property(c => c.Name).HasColumnName("name");
        builder.Property(c => c.Url).HasColumnName("url");

        // 91d21fc5-3c84-499d-b0f9-7b297738533c

        builder.HasData(new CategoryEntity
        {
            Id = Guid.Parse("91d21fc5-3c84-499d-b0f9-7b297738533c"),
            Name = "Books",
            Url = "books"
        });


        /*
         

        builder.HasData(
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
       ); */
    }
}
