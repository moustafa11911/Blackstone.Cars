using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Add_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRoads",
                table: "CarRoads");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarRoads",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRoads",
                table: "CarRoads",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarRoadLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarRoadId = table.Column<int>(nullable: false),
                    PassTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRoadLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRoadLogs_CarRoads_CarRoadId",
                        column: x => x.CarRoadId,
                        principalTable: "CarRoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRoads_CardId_RoadId",
                table: "CarRoads",
                columns: new[] { "CardId", "RoadId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarRoadLogs_CarRoadId",
                table: "CarRoadLogs",
                column: "CarRoadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRoadLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRoads",
                table: "CarRoads");

            migrationBuilder.DropIndex(
                name: "IX_CarRoads_CardId_RoadId",
                table: "CarRoads");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarRoads");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRoads",
                table: "CarRoads",
                columns: new[] { "CardId", "RoadId" });
        }
    }
}
