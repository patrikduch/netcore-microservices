//---------------------------------------------------------------------------
// <copyright file="ProductVariantConfiguration.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductVariantEntity = Domain.Entities.ProductVariantEntity;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariantEntity>
{
    public void Configure(EntityTypeBuilder<ProductVariantEntity> builder)
    {
        builder.ToTable("product-variant");
        builder.HasKey(pv => new { pv.Id, pv.ProductId, pv.ProductTypeId });

        builder.HasData(
               new ProductVariantEntity
               {
                   Id = Guid.Parse("bbf02f5f-6b6e-4e7e-a81d-fe504492b2bf"),
                   ProductId = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                   ProductTypeId = Guid.Parse("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                   Price = 9.99m,
                   OriginalPrice = 19.99m
               },
               new ProductVariantEntity
               {
                   Id = Guid.Parse("30a38fb1-ab79-447e-9f4a-860c8bbd62b4"),
                   ProductId = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                   ProductTypeId = Guid.Parse("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"),
                   Price = 7.99m
               },
               new ProductVariantEntity
               {
                   Id = Guid.Parse("3969771f-5401-4076-9880-be48be42306d"),
                   ProductId = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                   ProductTypeId = Guid.Parse("14ad27fb-2e94-407b-8e52-3376dc8f25fc"),
                   Price = 19.99m,
                   OriginalPrice = 29.99m
               },
               new ProductVariantEntity
               {
                   Id = Guid.Parse("5157a815-4955-490b-b7fb-75ff32a9e1e9"),
                   ProductId = Guid.Parse("6da738f1-9e86-4bd3-be73-74bd24d0986f"),
                   ProductTypeId = Guid.Parse("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                   Price = 7.99m,
                   OriginalPrice = 14.99m
               },
               new ProductVariantEntity
               {
                   Id = Guid.Parse("c7828d23-5241-433b-830d-3590dea897ee"),
                   ProductId = Guid.Parse("2b635271-8f13-4a63-a0e9-104d6506718d"),
                   ProductTypeId = Guid.Parse("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"),
                   Price = 6.99m
               },
               new ProductVariantEntity
               {
                   Id = Guid.Parse("e3bca2da-6722-48bc-8a00-76f9e6cc3cd8"),
                   ProductId = Guid.Parse("b34b571b-edfd-4188-ab06-545ffb6a627d"),
                   ProductTypeId = Guid.Parse("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                   Price = 3.99m
               }, 
               new ProductVariantEntity 
               { 
                   Id = Guid.Parse("57f2bd76-ddc9-438d-85b1-609b7fcf7e45"), 
                   ProductId = Guid.Parse("b34b571b-edfd-4188-ab06-545ffb6a627d"), 
                   ProductTypeId = Guid.Parse("5fb75212-e4eb-4b55-91f6-be056920398e"), 
                   Price = 9.99m
                }, 
               new ProductVariantEntity 
               { 
                   Id = Guid.Parse("1f892f4e-4cf9-4f2c-bfde-3d245d11375e"), 
                   ProductId = Guid.Parse("b34b571b-edfd-4188-ab06-545ffb6a627d"), 
                   ProductTypeId = Guid.Parse("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"), 
                   Price = 19.99m 
               }, 
               new ProductVariantEntity 
               {
                   Id = Guid.Parse("036ffc29-a1f8-40fa-af2a-b70783eb0242"),
                   ProductId = Guid.Parse("535852cd-5d28-4bd1-8852-7076618462c6"),
                   ProductTypeId = Guid.Parse("d1a105d9-ac4e-405a-8460-e54cd799d588"),
                   Price = 3.99m, 
               },
               new ProductVariantEntity 
               {
                   Id = Guid.Parse("97aa65f7-a29d-462b-adc1-7a9bcd37e45b"),
                   ProductId = Guid.Parse("d5925cb3-00be-4724-a478-04fb436be7f1"), 
                   ProductTypeId = Guid.Parse("d1a105d9-ac4e-405a-8460-e54cd799d588"), 
                   Price = 2.99m 
               }, 
               new ProductVariantEntity 
               {
                    Id = Guid.Parse("7720567c-3101-4a77-baf7-428bb4e34869"),
                    ProductId = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                    ProductTypeId = Guid.Parse("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                    Price = 19.99m,
                    OriginalPrice = 29.99m 
               }, 
               new ProductVariantEntity 
               {
                   Id = Guid.Parse("a5ad5e66-3d27-460f-97f1-be72ae934b19"),
                   ProductId = Guid.Parse("aacd2960-09c0-43eb-8e5b-1264804b3e1e"),
                   ProductTypeId = Guid.Parse("170955ba-98b9-47d2-bc0c-f2962ecba9c2"),
                   Price = 69.99m 
               }, 
               new ProductVariantEntity 
               {
                   Id = Guid.Parse("480ae336-a674-42fe-aedd-5e60bdcec77e"), 
                   ProductId = Guid.Parse("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), 
                   ProductTypeId = Guid.Parse("247c1e97-6a59-4473-94a4-f58564ea399f"), 
                   Price = 49.99m, 
                   OriginalPrice = 59.99m 
               }, 
               new ProductVariantEntity
               { 
                   Id = Guid.Parse("966574b6-ccea-4a39-a983-77b70b45ee9c"), 
                   ProductId = Guid.Parse("af8a4784-44cc-47e2-a2a3-8ef3363c1815"), 
                   ProductTypeId = Guid.Parse("2527d791-fecd-4721-8c91-a90a4f6f702a"), 
                   Price = 9.99m, 
                   OriginalPrice = 24.99m, 
               }, 
               new ProductVariantEntity
               {
                   Id = Guid.Parse("1d36ec7f-e0a5-44c4-b6e3-3e6a2495dc88"),
                   ProductId = Guid.Parse("2346bc18-4a78-422a-b8db-33195ac3ed3f"),
                   ProductTypeId = Guid.Parse("2527d791-fecd-4721-8c91-a90a4f6f702a"),
                   Price = 14.99m 
               },
                new ProductVariantEntity
                {
                    Id = Guid.Parse("966574b6-ccea-4a39-a983-77b70b45ee9c"),
                    ProductId = Guid.Parse("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"),
                    ProductTypeId = Guid.Parse("19f1c737-eae6-4bcf-b32f-45203e07282c"),
                    Price = 159.99m,
                    OriginalPrice = 299m
                },
                new ProductVariantEntity
                {
                    Id = Guid.Parse("966574b6-ccea-4a39-a983-77b70b45ee9c"),
                    ProductId = Guid.Parse("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"),
                    ProductTypeId = Guid.Parse("19f1c737-eae6-4bcf-b32f-45203e07282c"),
                    Price = 79.99m,
                    OriginalPrice = 399m
                }
           );
    }
}
