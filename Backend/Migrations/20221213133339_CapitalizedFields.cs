using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CapitalizedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Maps_mapId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_userId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Maps_mapId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_userId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "review",
                table: "Reviews",
                newName: "Review");

            migrationBuilder.RenameColumn(
                name: "mapId",
                table: "Reviews",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_userId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_mapId",
                table: "Reviews",
                newName: "IX_Reviews_MapId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Maps",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Maps",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Maps",
                newName: "Latitude");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_userId",
                table: "Maps",
                newName: "IX_Maps_UserId");

            migrationBuilder.RenameColumn(
                name: "surveyName",
                table: "Levels",
                newName: "SurveyName");

            migrationBuilder.RenameColumn(
                name: "surveyId",
                table: "Levels",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "previousSurveyId",
                table: "Levels",
                newName: "PreviousSurveyId");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "Buildings",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "Buildings",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "rotation",
                table: "Buildings",
                newName: "Rotation");

            migrationBuilder.RenameColumn(
                name: "mapId",
                table: "Buildings",
                newName: "MapId");

            migrationBuilder.RenameColumn(
                name: "buildingType",
                table: "Buildings",
                newName: "BuildingType");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_mapId",
                table: "Buildings",
                newName: "IX_Buildings_MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Maps_MapId",
                table: "Buildings",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_UserId",
                table: "Maps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Maps_MapId",
                table: "Reviews",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Maps_MapId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_UserId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Maps_MapId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Review",
                table: "Reviews",
                newName: "review");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Reviews",
                newName: "mapId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MapId",
                table: "Reviews",
                newName: "IX_Reviews_mapId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Maps",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Maps",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Maps",
                newName: "latitude");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_UserId",
                table: "Maps",
                newName: "IX_Maps_userId");

            migrationBuilder.RenameColumn(
                name: "SurveyName",
                table: "Levels",
                newName: "surveyName");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "Levels",
                newName: "surveyId");

            migrationBuilder.RenameColumn(
                name: "PreviousSurveyId",
                table: "Levels",
                newName: "previousSurveyId");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Buildings",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Buildings",
                newName: "x");

            migrationBuilder.RenameColumn(
                name: "Rotation",
                table: "Buildings",
                newName: "rotation");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Buildings",
                newName: "mapId");

            migrationBuilder.RenameColumn(
                name: "BuildingType",
                table: "Buildings",
                newName: "buildingType");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_MapId",
                table: "Buildings",
                newName: "IX_Buildings_mapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Maps_mapId",
                table: "Buildings",
                column: "mapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_userId",
                table: "Maps",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Maps_mapId",
                table: "Reviews",
                column: "mapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_userId",
                table: "Reviews",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
