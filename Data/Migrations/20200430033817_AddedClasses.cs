using Microsoft.EntityFrameworkCore.Migrations;

namespace CoquoRev4.Data.Migrations
{
    public partial class AddedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(nullable: true),
                    DishDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(nullable: true),
                    IngredientDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    CookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishID = table.Column<int>(nullable: false),
                    IngredientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.CookID);
                    table.ForeignKey(
                        name: "FK_Cooks_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooks_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_DishID",
                table: "Cooks",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_IngredientID",
                table: "Cooks",
                column: "IngredientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
