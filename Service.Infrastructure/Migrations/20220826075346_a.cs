using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Infrastructure.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "materials");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "materials");

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "materials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
