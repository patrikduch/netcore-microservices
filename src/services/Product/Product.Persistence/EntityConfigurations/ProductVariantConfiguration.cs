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
               }
           );
    }
}
