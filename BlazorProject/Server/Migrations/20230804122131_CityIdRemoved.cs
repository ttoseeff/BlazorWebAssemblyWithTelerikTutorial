using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProject.Server.Migrations
{
    public partial class CityIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CityId",
                table: "Publishers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Cities_CityId",
                table: "Publishers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Cities_CityId",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_CityId",
                table: "Publishers");

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
