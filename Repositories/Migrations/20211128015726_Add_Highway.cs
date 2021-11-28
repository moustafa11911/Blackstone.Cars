using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Add_Highway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardTypeId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "CarHighway",
                columns: table => new
                {
                    HighwayId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    PassCost = table.Column<decimal>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarHighway_CarId",
                table: "CarHighway",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarHighway");

            migrationBuilder.AddColumn<int>(
                name: "CardTypeId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards",
                column: "CardTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards",
                column: "CardTypeId",
                principalTable: "CardTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
