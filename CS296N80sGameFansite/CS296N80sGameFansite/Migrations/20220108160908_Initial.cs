using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N80sGameFansite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInfo",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Platform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfo", x => x.GameID);
                });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "GameID", "Name", "Platform", "Year" },
                values: new object[] { 1, "Tetris", "Nintendo", 1989 });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "GameID", "Name", "Platform", "Year" },
                values: new object[] { 2, "Donkey Kong", "Arcade", 1981 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInfo");
        }
    }
}
