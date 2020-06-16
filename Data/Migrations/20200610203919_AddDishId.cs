using Microsoft.EntityFrameworkCore.Migrations;

namespace CoquoRev4.Data.Migrations
{
    public partial class AddDishId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishID",
                table: "Ingredients",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishID",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "Ingredients");
        }
    }
}
