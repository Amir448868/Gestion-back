using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carniceria.Migrations
{
    /// <inheritdoc />
    public partial class nuevarelacion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_idProduct",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_idProduct",
                table: "Sales",
                column: "idProduct",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_idProduct",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_idProduct",
                table: "Sales",
                column: "idProduct",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
