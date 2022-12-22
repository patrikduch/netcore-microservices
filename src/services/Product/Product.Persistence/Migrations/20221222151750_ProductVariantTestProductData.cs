using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductVariantTestProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product-variant",
                columns: new[] { "Id", "ProductId", "ProductTypeId", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { new Guid("036ffc29-a1f8-40fa-af2a-b70783eb0242"), new Guid("535852cd-5d28-4bd1-8852-7076618462c6"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 3.99m },
                    { new Guid("1d36ec7f-e0a5-44c4-b6e3-3e6a2495dc88"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 14.99m },
                    { new Guid("1f892f4e-4cf9-4f2c-bfde-3d245d11375e"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 19.99m },
                    { new Guid("480ae336-a674-42fe-aedd-5e60bdcec77e"), new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), new Guid("247c1e97-6a59-4473-94a4-f58564ea399f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 59.99m, 49.99m },
                    { new Guid("5157a815-4955-490b-b7fb-75ff32a9e1e9"), new Guid("6da738f1-9e86-4bd3-be73-74bd24d0986f"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 14.99m, 7.99m },
                    { new Guid("57f2bd76-ddc9-438d-85b1-609b7fcf7e45"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("5fb75212-e4eb-4b55-91f6-be056920398e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 9.99m },
                    { new Guid("7720567c-3101-4a77-baf7-428bb4e34869"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 29.99m, 19.99m },
                    { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"), new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 299m, 159.99m },
                    { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"), new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 399m, 79.99m },
                    { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("af8a4784-44cc-47e2-a2a3-8ef3363c1815"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 24.99m, 9.99m },
                    { new Guid("97aa65f7-a29d-462b-adc1-7a9bcd37e45b"), new Guid("d5925cb3-00be-4724-a478-04fb436be7f1"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 2.99m },
                    { new Guid("a5ad5e66-3d27-460f-97f1-be72ae934b19"), new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 69.99m },
                    { new Guid("c7828d23-5241-433b-830d-3590dea897ee"), new Guid("2b635271-8f13-4a63-a0e9-104d6506718d"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 6.99m },
                    { new Guid("e3bca2da-6722-48bc-8a00-76f9e6cc3cd8"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0m, 3.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("036ffc29-a1f8-40fa-af2a-b70783eb0242"), new Guid("535852cd-5d28-4bd1-8852-7076618462c6"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("1d36ec7f-e0a5-44c4-b6e3-3e6a2495dc88"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("1f892f4e-4cf9-4f2c-bfde-3d245d11375e"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("480ae336-a674-42fe-aedd-5e60bdcec77e"), new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), new Guid("247c1e97-6a59-4473-94a4-f58564ea399f") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("5157a815-4955-490b-b7fb-75ff32a9e1e9"), new Guid("6da738f1-9e86-4bd3-be73-74bd24d0986f"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("57f2bd76-ddc9-438d-85b1-609b7fcf7e45"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("5fb75212-e4eb-4b55-91f6-be056920398e") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("7720567c-3101-4a77-baf7-428bb4e34869"), new Guid("2346bc18-4a78-422a-b8db-33195ac3ed3f"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("4f498e40-e6cc-43d9-bf0f-284e20da7e6a"), new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"), new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("966574b6-ccea-4a39-a983-77b70b45ee9c"), new Guid("af8a4784-44cc-47e2-a2a3-8ef3363c1815"), new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("97aa65f7-a29d-462b-adc1-7a9bcd37e45b"), new Guid("d5925cb3-00be-4724-a478-04fb436be7f1"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("a5ad5e66-3d27-460f-97f1-be72ae934b19"), new Guid("aacd2960-09c0-43eb-8e5b-1264804b3e1e"), new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("c7828d23-5241-433b-830d-3590dea897ee"), new Guid("2b635271-8f13-4a63-a0e9-104d6506718d"), new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b") });

            migrationBuilder.DeleteData(
                table: "product-variant",
                keyColumns: new[] { "Id", "ProductId", "ProductTypeId" },
                keyValues: new object[] { new Guid("e3bca2da-6722-48bc-8a00-76f9e6cc3cd8"), new Guid("b34b571b-edfd-4188-ab06-545ffb6a627d"), new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588") });
        }
    }
}
