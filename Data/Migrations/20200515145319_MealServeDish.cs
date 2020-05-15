using Microsoft.EntityFrameworkCore.Migrations;

namespace CoquoRev4.Data.Migrations
{
    public partial class MealServeDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DishCuisine",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(nullable: true),
                    MealDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealID);
                });

            migrationBuilder.CreateTable(
                name: "Serve",
                columns: table => new
                {
                    ServeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealID = table.Column<int>(nullable: false),
                    MealName = table.Column<string>(nullable: true),
                    DishID = table.Column<int>(nullable: false),
                    DishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serve", x => x.ServeID);
                    table.ForeignKey(
                        name: "FK_Serve_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serve_Meal_MealID",
                        column: x => x.MealID,
                        principalTable: "Meal",
                        principalColumn: "MealID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serve_DishID",
                table: "Serve",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Serve_MealID",
                table: "Serve",
                column: "MealID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serve");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropColumn(
                name: "DishCuisine",
                table: "Dishes");
        }
    }
}
