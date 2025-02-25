using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootHub.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCartNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ShoeId",
                table: "ShoppingCarts",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Shoes_ShoeId",
                table: "ShoppingCarts",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Shoes_ShoeId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_ShoeId",
                table: "ShoppingCarts");
        }
    }
}
