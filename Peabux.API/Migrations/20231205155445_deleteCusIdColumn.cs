using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peabux.API.Migrations
{
    /// <inheritdoc />
    public partial class deleteCusIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Customers_CustomerId",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_CustomerId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Merchants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CustomerId",
                table: "Merchants",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Customers_CustomerId",
                table: "Merchants",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
