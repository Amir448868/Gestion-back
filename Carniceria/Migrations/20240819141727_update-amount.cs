using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carniceria.Migrations
{
    /// <inheritdoc />
    public partial class updateamount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kg",
                table: "Sales",
                newName: "amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Sales",
                newName: "kg");
        }
    }
}
