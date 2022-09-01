using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request.Infrastructure.Migrations
{
    public partial class addconfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "requests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "requests");
        }
    }
}
