using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductTypeTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product-type",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Audiobook" },
                    { new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "PlayStation" },
                    { new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Default" },
                    { new Guid("247c1e97-6a59-4473-94a4-f58564ea399f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Xbox" },
                    { new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "PC" },
                    { new Guid("5fb75212-e4eb-4b55-91f6-be056920398e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Blu-ray" },
                    { new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "E-Book" },
                    { new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "VHS" },
                    { new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Stream" },
                    { new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Paperback" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("14ad27fb-2e94-407b-8e52-3376dc8f25fc"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("170955ba-98b9-47d2-bc0c-f2962ecba9c2"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("19f1c737-eae6-4bcf-b32f-45203e07282c"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("247c1e97-6a59-4473-94a4-f58564ea399f"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("2527d791-fecd-4721-8c91-a90a4f6f702a"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("5fb75212-e4eb-4b55-91f6-be056920398e"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("751287ba-53f6-4874-b7b2-dc7b39ff6e9f"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("a0cc00af-f1c2-46be-9c5e-a6f4e0f69069"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("d1a105d9-ac4e-405a-8460-e54cd799d588"));

            migrationBuilder.DeleteData(
                table: "product-type",
                keyColumn: "Id",
                keyValue: new Guid("f4a6c9cc-cd6e-42d4-87be-f83e2cf2826b"));
        }
    }
}
