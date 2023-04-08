//---------------------------------------------------------------------------
// <copyright file="CategoryConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.EntityConfigurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Entity configuration for  <seealso cref="CategoryEntity"/>.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    /// <summary>
    /// Configuration setup of <seealso cref="CategoryEntity"/>.
    /// </summary>
    /// <param name="builder"><seealso cref="CategoryEntity"/> builder object.</param>
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("category");
        builder.HasKey(c => c.Id).HasName("id");
        builder.Property(c => c.Name).HasColumnName("name");
        builder.Property(c => c.Url).HasColumnName("url");


        builder.HasData(
            new CategoryEntity
            {
                Id = Guid.Parse("91d21fc5-3c84-499d-b0f9-7b297738533c"),
                Name = "Books",
                Url = "books"
            },

            new CategoryEntity
            {
                Id = Guid.Parse("a5a546aa-4d13-4318-b4de-04dbf94259be"),
                Name = "Movies",
                Url = "movies"
            },

            new CategoryEntity
            {
                Id = Guid.Parse("139abf65-bb9b-4d41-96d8-6c623542ae8d"),
                Name = "Video Games",
                Url = "video-games"
            }
        );
    }
}
