using Microsoft.EntityFrameworkCore.Migrations;

namespace LazadaAPITest.Migrations
{
    public partial class addPropertyOfRatingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Percent_Star",
                table: "RatingInfo",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent_Star",
                table: "RatingInfo");
        }
    }
}
