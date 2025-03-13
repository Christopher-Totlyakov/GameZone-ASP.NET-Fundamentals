using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class ContextUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_PublissherId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Genre_GenreId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Game_GameId",
                table: "GamersGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameColumn(
                name: "PublissherId",
                table: "Games",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "IsDeletrd",
                table: "Games",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Game_PublissherId",
                table: "Games",
                newName: "IX_Games_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_GenreId",
                table: "Games",
                newName: "IX_Games_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genre_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genre_GenreId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Game",
                newName: "PublissherId");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Game",
                newName: "IsDeletrd");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublisherId",
                table: "Game",
                newName: "IX_Game_PublissherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreId",
                table: "Game",
                newName: "IX_Game_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_PublissherId",
                table: "Game",
                column: "PublissherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Genre_GenreId",
                table: "Game",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Game_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }
    }
}
