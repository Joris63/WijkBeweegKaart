using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RedoneUserLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels");

            migrationBuilder.DropIndex(
                name: "IX_UserLevels_userId",
                table: "UserLevels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserLevels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLevels_userId",
                table: "UserLevels",
                column: "userId");
        }
    }
}
