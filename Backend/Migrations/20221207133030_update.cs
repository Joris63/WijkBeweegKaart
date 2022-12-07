using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels",
                columns: new[] { "userId", "levelId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLevels",
                table: "UserLevels",
                column: "userId");
        }
    }
}
