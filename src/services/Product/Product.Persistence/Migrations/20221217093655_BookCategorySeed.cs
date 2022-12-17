using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class BookCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "name", "url" },
                values: new object[] { new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Books", "books" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("91d21fc5-3c84-499d-b0f9-7b297738533c"));
        }
    }
}
