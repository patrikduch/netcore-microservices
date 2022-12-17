using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class VideoGameCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "name", "url" },
                values: new object[] { new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Video Games", "video-games" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("139abf65-bb9b-4d41-96d8-6c623542ae8d"));
        }
    }
}
