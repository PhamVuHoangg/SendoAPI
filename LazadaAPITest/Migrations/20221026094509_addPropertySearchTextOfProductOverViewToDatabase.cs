using Microsoft.EntityFrameworkCore.Migrations;

namespace LazadaAPITest.Migrations
{
    public partial class addPropertySearchTextOfProductOverViewToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchText",
                table: "ProductOverView",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchText",
                table: "ProductOverView");
        }
    }
}
