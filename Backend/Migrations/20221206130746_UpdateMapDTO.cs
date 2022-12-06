using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMapDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_UserDTOId",
                table: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Maps_UserDTOId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "UserDTOId",
                table: "Maps");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Maps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maps_userId",
                table: "Maps",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_userId",
                table: "Maps",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Users_userId",
                table: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Maps_userId",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Maps");

            migrationBuilder.AddColumn<int>(
                name: "UserDTOId",
                table: "Maps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maps_UserDTOId",
                table: "Maps",
                column: "UserDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Users_UserDTOId",
                table: "Maps",
                column: "UserDTOId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
