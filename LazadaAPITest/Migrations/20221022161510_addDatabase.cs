using Microsoft.EntityFrameworkCore.Migrations;

namespace LazadaAPITest.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total_Rated = table.Column<int>(type: "int", nullable: false),
                    Percent_Star1 = table.Column<int>(type: "int", nullable: false),
                    Percent_Star2 = table.Column<int>(type: "int", nullable: false),
                    Percent_Star3 = table.Column<int>(type: "int", nullable: false),
                    Percent_Star4 = table.Column<int>(type: "int", nullable: false),
                    Percent_Star5 = table.Column<int>(type: "int", nullable: false),
                    Star1 = table.Column<int>(type: "int", nullable: false),
                    Star2 = table.Column<int>(type: "int", nullable: false),
                    Star3 = table.Column<int>(type: "int", nullable: false),
                    Star4 = table.Column<int>(type: "int", nullable: false),
                    Star5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shop_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shop_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shop_Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating_Avg = table.Column<float>(type: "real", nullable: false),
                    Rating_Count = table.Column<int>(type: "int", nullable: false),
                    Product_Total = table.Column<int>(type: "int", nullable: false),
                    Warehourse_Region_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Short_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Shop_InfoId = table.Column<int>(type: "int", nullable: true),
                    Description_InfoId = table.Column<int>(type: "int", nullable: true),
                    Rating_InfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_DescriptionInfo_Description_InfoId",
                        column: x => x.Description_InfoId,
                        principalTable: "DescriptionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetail_RatingInfo_Rating_InfoId",
                        column: x => x.Rating_InfoId,
                        principalTable: "RatingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetail_ShopInfo_Shop_InfoId",
                        column: x => x.Shop_InfoId,
                        principalTable: "ShopInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryInfo",
                columns: table => new
                {
                    dbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetailId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryInfo", x => x.dbId);
                    table.ForeignKey(
                        name: "FK_CategoryInfo_ProductDetail_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOverView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOverView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOverView_ProductDetail_DataId",
                        column: x => x.DataId,
                        principalTable: "ProductDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryInfo_ProductDetailId",
                table: "CategoryInfo",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_Description_InfoId",
                table: "ProductDetail",
                column: "Description_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_Rating_InfoId",
                table: "ProductDetail",
                column: "Rating_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_Shop_InfoId",
                table: "ProductDetail",
                column: "Shop_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOverView_DataId",
                table: "ProductOverView",
                column: "DataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CategoryInfo");

            migrationBuilder.DropTable(
                name: "ProductOverView");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "DescriptionInfo");

            migrationBuilder.DropTable(
                name: "RatingInfo");

            migrationBuilder.DropTable(
                name: "ShopInfo");
        }
    }
}
