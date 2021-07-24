using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PurchaseRelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_User_userId",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Purchase",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_userId",
                table: "Purchase",
                newName: "IX_Purchase_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_User_UserId",
                table: "Purchase",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_User_UserId",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Purchase",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                newName: "IX_Purchase_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_User_userId",
                table: "Purchase",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
