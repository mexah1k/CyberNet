using Microsoft.EntityFrameworkCore.Migrations;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Migrations
{
    public partial class SeedSeriesTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("SeriesTypes", new[] { "id", "name" }, new object[] { (int)SeriesEnum.Bo1, SeriesEnum.Bo1.ToString() });
            migrationBuilder.InsertData("SeriesTypes", new[] { "id", "name" }, new object[] { (int)SeriesEnum.Bo2, SeriesEnum.Bo2.ToString() });
            migrationBuilder.InsertData("SeriesTypes", new[] { "id", "name" }, new object[] { (int)SeriesEnum.Bo3, SeriesEnum.Bo3.ToString() });
            migrationBuilder.InsertData("SeriesTypes", new[] { "id", "name" }, new object[] { (int)SeriesEnum.Bo5, SeriesEnum.Bo5.ToString() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SeriesTypes", true);
        }
    }
}
