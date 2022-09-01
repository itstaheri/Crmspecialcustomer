using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request.Infrastructure.Migrations
{
    public partial class editrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_requests_requestModelId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_requestModelId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "requestModelId",
                table: "services");

            migrationBuilder.CreateIndex(
                name: "IX_requests_ServiceId",
                table: "requests",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_services_ServiceId",
                table: "requests",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_services_ServiceId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ServiceId",
                table: "requests");

            migrationBuilder.AddColumn<long>(
                name: "requestModelId",
                table: "services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_services_requestModelId",
                table: "services",
                column: "requestModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_requests_requestModelId",
                table: "services",
                column: "requestModelId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
