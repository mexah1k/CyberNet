using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Data.Core.Migrations
{
    public partial class AddWinnerTeamToSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerTeamId",
                table: "Series",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_WinnerTeamId",
                table: "Series",
                column: "WinnerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Teams_WinnerTeamId",
                table: "Series",
                column: "WinnerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Teams_WinnerTeamId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_WinnerTeamId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "WinnerTeamId",
                table: "Series");
        }
    }
}
