//---------------------------------------------------------------------------
// <copyright file="ProductTypeConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
{
    public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
    {
        builder.ToTable("product-type");

        builder.HasData(      
            new ProductTypeEntity { Id = Guid.Parse("19f1c737-eae6-4bcf-b32f-45203e07282c"), Name = "Default" },       
            new ProductTypeEntity { Id = Guid.Parse("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"), Name = "Paperback" },       
            new ProductTypeEntity { Id = Guid.Parse("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"), Name = "E-Book" },       
            new ProductTypeEntity { Id = Guid.Parse("14ad27fb-2e94-407b-8e52-3376dc8f25fc"), Name = "Audiobook" },       
            new ProductTypeEntity { Id = Guid.Parse("d1a105d9-ac4e-405a-8460-e54cd799d588"), Name = "Stream" },       
            new ProductTypeEntity { Id = Guid.Parse("5fb75212-e4eb-4b55-91f6-be056920398e"), Name = "Blu-ray" },       
            new ProductTypeEntity { Id = Guid.Parse("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"), Name = "VHS" },       
            new ProductTypeEntity { Id = Guid.Parse("2527d791-fecd-4721-8c91-a90a4f6f702a"), Name = "PC" },       
            new ProductTypeEntity { Id = Guid.Parse("170955ba-98b9-47d2-bc0c-f2962ecba9c2"), Name = "PlayStation" },       
            new ProductTypeEntity { Id = Guid.Parse("247c1e97-6a59-4473-94a4-f58564ea399f"), Name = "Xbox" }        
       );
    }
}
