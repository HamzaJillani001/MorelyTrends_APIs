using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorelyTrends.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fees",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RRP",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fees",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RRP",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Products",
                newName: "Price");
        }
    }
}
