using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Data.Core.Migrations
{
    public partial class UpdateSeriesTypeIdNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeriesTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "SeriesTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Bo5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeriesTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "SeriesTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Bo5" });
        }
    }
}
