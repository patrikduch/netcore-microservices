using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductVariantFirstProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product-variant",
                columns: new[] { "Id", "ProductId", "ProductTypeId", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { new Guid("30a38fb1-ab79-447e-9f4a-860c8bbd62b4"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 7.99m },
                    { new Guid("3969771f-5401-4076-9880-be48be42306d"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 29.99m, 19.99m },
                    { new Guid("bbf02f5f-6b6e-4e7e-a81d-fe504492b2bf"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 19.99m, 9.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("30a38fb1-ab79-447e-9f4a-860c8bbd62b4"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("3969771f-5401-4076-9880-be48be42306d"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("bbf02f5f-6b6e-4e7e-a81d-fe504492b2bf"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b") });
        }
    }
}
