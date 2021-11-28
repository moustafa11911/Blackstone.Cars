using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Remove_CarId_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Cars_CarId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CarId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CarId",
                table: "Cards",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Cars_CarId",
                table: "Cards",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
