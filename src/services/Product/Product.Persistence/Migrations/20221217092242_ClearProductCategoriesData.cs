using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Persistence.Migrations
{
    public partial class ClearProductCategoriesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM public.category;");
            migrationBuilder.Sql("DELETE FROM public.product;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
