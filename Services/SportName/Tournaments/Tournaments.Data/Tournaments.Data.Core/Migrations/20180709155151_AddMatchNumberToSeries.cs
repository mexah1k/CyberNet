using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Data.Core.Migrations
{
    public partial class AddMatchNumberToSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfMatches",
                table: "Series",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfMatches",
                table: "Series");
        }
    }
}
