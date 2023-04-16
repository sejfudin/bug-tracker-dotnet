using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bug_tracker.Migrations
{
    /// <inheritdoc />
    public partial class UserBugRelationsip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bugs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_UserId",
                table: "Bugs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Users_UserId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_UserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bugs");
        }
    }
}
