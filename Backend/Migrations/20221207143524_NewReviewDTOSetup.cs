using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewReviewDTOSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Maps_reviewedMapId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_writerId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "writerId",
                table: "Reviews",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "reviewedMapId",
                table: "Reviews",
                newName: "mapId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_writerId",
                table: "Reviews",
                newName: "IX_Reviews_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_reviewedMapId",
                table: "Reviews",
                newName: "IX_Reviews_mapId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Maps_mapId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_userId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reviews",
                newName: "writerId");

            migrationBuilder.RenameColumn(
                name: "mapId",
                table: "Reviews",
                newName: "reviewedMapId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_userId",
                table: "Reviews",
                newName: "IX_Reviews_writerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_mapId",
                table: "Reviews",
                newName: "IX_Reviews_reviewedMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Maps_reviewedMapId",
                table: "Reviews",
                column: "reviewedMapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_writerId",
                table: "Reviews",
                column: "writerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
