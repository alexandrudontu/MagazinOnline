using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace magazinOnline.Migrations.ApplicationDb
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCarts_CartProducts_CartProductId",
                table: "CustomerCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCarts_CartProductId",
                table: "CustomerCarts");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "CustomerOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerCartId",
                table: "CartProducts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CustomerCartId",
                table: "CartProducts",
                column: "CustomerCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_CustomerCarts_CustomerCartId",
                table: "CartProducts",
                column: "CustomerCartId",
                principalTable: "CustomerCarts",
                principalColumn: "CustomerCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_CustomerCarts_CustomerCartId",
                table: "CartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_CustomerCartId",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "CustomerCartId",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartProducts");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "CustomerOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCarts_CartProductId",
                table: "CustomerCarts",
                column: "CartProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCarts_CartProducts_CartProductId",
                table: "CustomerCarts",
                column: "CartProductId",
                principalTable: "CartProducts",
                principalColumn: "CartProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
