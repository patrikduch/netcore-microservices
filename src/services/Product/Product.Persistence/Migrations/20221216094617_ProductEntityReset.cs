using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ProductEntityReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE public.product;");
            migrationBuilder.Sql("DELETE FROM public.product;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
