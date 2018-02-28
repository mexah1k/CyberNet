using Microsoft.EntityFrameworkCore.Migrations;
using Teams.Data.Entities.Enum;

namespace Teams.Data.Core.Migrations
{
    public partial class SeedPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // todo: make it invariant
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Midlane, PositionEnum.Midlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Carry, PositionEnum.Carry.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Hardlane, PositionEnum.Hardlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Offlane, PositionEnum.Offlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Support, PositionEnum.Support.ToString() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
