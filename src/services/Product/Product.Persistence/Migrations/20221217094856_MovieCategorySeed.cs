using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class MovieCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "name", "url" },
                values: new object[] { new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Movies", "movies" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("a5a546aa-4d13-4318-b4de-04dbf94259be"));
        }
    }
}
