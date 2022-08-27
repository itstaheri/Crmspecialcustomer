using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Infrastructure.Migrations
{
    public partial class removeservicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "materials");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "PriceList");

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "PriceList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceList",
                table: "PriceList",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceList",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "PriceList");

            migrationBuilder.RenameTable(
                name: "PriceList",
                newName: "materials");

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "materials",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "serviceNames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceNames", x => x.Id);
                });
        }
    }
}
