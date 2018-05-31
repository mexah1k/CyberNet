﻿using Microsoft.EntityFrameworkCore.Migrations;
using Tournaments.Data.Entities.Enum;

namespace Tournaments.Data.Core.Migrations
{
    public partial class SeedPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Midlane, PositionEnum.Midlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Carry, PositionEnum.Carry.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Hardlane, PositionEnum.Hardlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Offlane, PositionEnum.Offlane.ToString() });
            migrationBuilder.InsertData("Positions", new[] { "id", "name" }, new object[] { (int)PositionEnum.Support, PositionEnum.Support.ToString() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Positions", true);
        }
    }
}