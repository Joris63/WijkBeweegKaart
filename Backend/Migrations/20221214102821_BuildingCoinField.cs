using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class BuildingCoinField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Maps_MapId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Reviews",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MapId",
                table: "Reviews",
                newName: "IX_Reviews_BuildingId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoinAmount",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Buildings_BuildingId",
                table: "Reviews",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Buildings_BuildingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CoinAmount",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Reviews",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BuildingId",
                table: "Reviews",
                newName: "IX_Reviews_MapId");

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Maps_MapId",
                table: "Reviews",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
