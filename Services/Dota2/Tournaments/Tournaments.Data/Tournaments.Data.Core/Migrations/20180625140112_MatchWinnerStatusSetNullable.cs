using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Data.Core.Migrations
{
    public partial class MatchWinnerStatusSetNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRadiantWin",
                table: "Matches",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRadiantWin",
                table: "Matches",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
