using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationForRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Maps_MapId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Maps");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Regions",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_MapId",
                table: "Regions",
                newName: "IX_Regions_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_LocationId",
                table: "Maps",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Locations_LocationId",
                table: "Maps",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Locations_LocationId",
                table: "Regions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Locations_LocationId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Locations_LocationId",
                table: "Regions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Maps_LocationId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Maps");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Regions",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_LocationId",
                table: "Regions",
                newName: "IX_Regions_MapId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Maps",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Maps",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Maps_MapId",
                table: "Regions",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
