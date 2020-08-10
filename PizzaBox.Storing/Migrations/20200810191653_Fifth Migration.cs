using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Topping",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topping_PizzaId",
                table: "Topping",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizza_PizzaId",
                table: "Topping",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizza_PizzaId",
                table: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_Topping_PizzaId",
                table: "Topping");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Topping");

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: true),
                    ToppingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_PizzaId",
                table: "PizzaTopping",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }
    }
}
