using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductTestDataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("142d6434-62d5-493e-8044-f23781275efa"));

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "CategoryId", "CreatedAt", "CreatedBy", "description", "imgurl", "LastModifiedBy", "LastModifiedDate", "name" },
                values: new object[] { new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", null, null, "Super Nintendo Entertainment System" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("8eb4489a-b2dc-415c-b9a2-f946a01a2c0e"));

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "CategoryId", "CreatedAt", "CreatedBy", "description", "imgurl", "LastModifiedBy", "LastModifiedDate", "name" },
                values: new object[] { new Guid("142d6434-62d5-493e-8044-f23781275efa"), new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", null, null, "Super Nintendo Entertainment System" });
        }
    }
}
