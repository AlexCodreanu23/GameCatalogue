using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class AddGameDeveloperRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDevelopers");

            migrationBuilder.CreateTable(
                name: "GameDeveloper",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    GameDeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloper", x => new { x.GameId, x.DeveloperId });
                    table.ForeignKey(
                        name: "FK_GameDeveloper_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloper_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDeveloper_DeveloperId",
                table: "GameDeveloper",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDeveloper");

            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    DevelopersDeveloperId = table.Column<int>(type: "int", nullable: false),
                    GamesGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => new { x.DevelopersDeveloperId, x.GamesGameId });
                    table.ForeignKey(
                        name: "FK_GameDevelopers_Developers_DevelopersDeveloperId",
                        column: x => x.DevelopersDeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDevelopers_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_GamesGameId",
                table: "GameDevelopers",
                column: "GamesGameId");
        }
    }
}
