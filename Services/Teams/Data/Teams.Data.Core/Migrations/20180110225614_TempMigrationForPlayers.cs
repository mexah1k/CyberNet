using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Core.Migrations
{
    public partial class TempMigrationForPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teams");
        }
    }
}
