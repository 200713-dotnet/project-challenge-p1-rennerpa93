using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Order_OrderId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Pizzas_PizzaId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Pizza");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizza",
                newName: "IX_Pizza_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizza",
                newName: "IX_Pizza_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CrustId",
                table: "Pizza",
                newName: "IX_Pizza_CrustId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustId",
                table: "Pizza",
                column: "CrustId",
                principalTable: "Crust",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Order_OrderId",
                table: "Pizza",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeId",
                table: "Pizza",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Pizza_PizzaId",
                table: "PizzaTopping",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Crust_CrustId",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Order_OrderId",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Size_SizeId",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Pizza_PizzaId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza");

            migrationBuilder.RenameTable(
                name: "Pizza",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizzas",
                newName: "IX_Pizzas_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizzas",
                newName: "IX_Pizzas_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizzas",
                newName: "IX_Pizzas_CrustId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "Crust",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Order_OrderId",
                table: "Pizzas",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Size_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Pizzas_PizzaId",
                table: "PizzaTopping",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
