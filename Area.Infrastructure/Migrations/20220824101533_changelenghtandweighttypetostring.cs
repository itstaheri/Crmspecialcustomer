using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Area.Infrastructure.Migrations
{
    public partial class changelenghtandweighttypetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "centers");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "centers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Lenght",
                table: "centers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "centers");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "centers",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "centers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
