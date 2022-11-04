using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "LastModifiedBy", "LastModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("b491c6d3-1747-485e-a64f-b80d9b1277e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patrikduch@test.com", null, null, new byte[] { 171, 206, 35, 238, 154, 252, 183, 232, 136, 145, 46, 120, 46, 109, 199, 41, 61, 52, 60, 72, 211, 22, 14, 19, 43, 139, 139, 109, 193, 147, 160, 179, 59, 123, 78, 76, 95, 226, 16, 101, 134, 48, 177, 191, 63, 10, 166, 243, 162, 248, 208, 211, 50, 165, 250, 218, 85, 99, 47, 65, 186, 228, 234, 69 }, new byte[] { 115, 179, 226, 112, 196, 173, 244, 184, 176, 67, 214, 219, 91, 58, 76, 55, 53, 173, 140, 191, 21, 153, 228, 104, 13, 17, 112, 89, 238, 113, 190, 76, 54, 160, 116, 233, 199, 20, 149, 154, 93, 134, 89, 47, 21, 27, 60, 0, 138, 161, 15, 21, 107, 225, 113, 205, 153, 156, 227, 165, 118, 204, 181, 94, 164, 15, 165, 89, 82, 134, 160, 38, 215, 151, 208, 199, 237, 174, 2, 135, 11, 219, 24, 34, 132, 25, 250, 243, 37, 158, 182, 197, 236, 125, 45, 64, 194, 89, 159, 10, 99, 214, 128, 134, 183, 164, 247, 242, 211, 55, 226, 246, 196, 2, 6, 96, 63, 38, 145, 0, 63, 119, 238, 74, 205, 147, 6, 200 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
