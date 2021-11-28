using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Add_Road : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarHighway");

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarRoads",
                columns: table => new
                {
                    RoadId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    PassCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRoads", x => new { x.CardId, x.RoadId });
                    table.ForeignKey(
                        name: "FK_CarRoads_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRoads_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarRoads_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRoads_CarId",
                table: "CarRoads",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRoads_RoadId",
                table: "CarRoads",
                column: "RoadId");

            migrationBuilder.Sql(@"Insert into Roads values ('Shubra-Banha highway'), ('Suez highway')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRoads");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.CreateTable(
                name: "CarHighway",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    HighwayId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PassCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarHighway", x => new { x.CardId, x.HighwayId });
                    table.ForeignKey(
                        name: "FK_CarHighway_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarHighway_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarHighway_CarId",
                table: "CarHighway",
                column: "CarId");

            migrationBuilder.Sql(@"Delete from roads");
        }
    }
}
