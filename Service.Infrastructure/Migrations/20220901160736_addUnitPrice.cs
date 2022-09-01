using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Infrastructure.Migrations
{
    public partial class addUnitPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "PriceList",
                newName: "UnitOfMaterial");

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "PriceList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "PriceList");

            migrationBuilder.RenameColumn(
                name: "UnitOfMaterial",
                table: "PriceList",
                newName: "Unit");
        }
    }
}
