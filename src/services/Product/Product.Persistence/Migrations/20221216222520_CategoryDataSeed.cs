using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class CategoryDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "name", "url" },
                values: new object[,]
                {
                    { new Guid("430c6139-b227-449e-9936-d6e398eebeab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Video Games", "video-games" },
                    { new Guid("52ca3d2e-1cd8-4247-bf8e-5ac8267d2de5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Movies", "movies" },
                    { new Guid("a5fc30db-2d2e-44fb-b2e1-ab18ad43c691"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Books", "books" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("430c6139-b227-449e-9936-d6e398eebeab"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("52ca3d2e-1cd8-4247-bf8e-5ac8267d2de5"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("a5fc30db-2d2e-44fb-b2e1-ab18ad43c691"));
        }
    }
}
