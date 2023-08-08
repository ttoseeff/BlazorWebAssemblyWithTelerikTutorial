using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProject.Server.Migrations
{
    public partial class CityForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Publishers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CityId1",
                table: "Publishers",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Cities_CityId1",
                table: "Publishers",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Cities_CityId1",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_CityId1",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Publishers");
        }
    }
}
