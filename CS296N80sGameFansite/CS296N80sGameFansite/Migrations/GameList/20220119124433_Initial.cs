using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N80sGameFansite.Migrations.GameList
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayedInfo",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Platform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayedInfo", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "WantToPlayInfo",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Platform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantToPlayInfo", x => x.GameID);
                });

            migrationBuilder.InsertData(
                table: "PlayedInfo",
                columns: new[] { "GameID", "Name", "Platform", "Year" },
                values: new object[,]
                {
                    { 1, "Tetris", "Nintendo", 1989 },
                    { 2, "Donkey Kong", "Arcade", 1981 }
                });

            migrationBuilder.InsertData(
                table: "WantToPlayInfo",
                columns: new[] { "GameID", "Name", "Platform", "Year" },
                values: new object[,]
                {
                    { 1, "Tetris", "Nintendo", 1989 },
                    { 2, "Test", "Testrix", 1981 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayedInfo");

            migrationBuilder.DropTable(
                name: "WantToPlayInfo");
        }
    }
}
