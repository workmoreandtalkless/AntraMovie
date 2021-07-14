using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdatedMovieandRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Movie_MovieId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_MovieId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_MovieId",
                table: "Role",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Movie_MovieId",
                table: "Role",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
