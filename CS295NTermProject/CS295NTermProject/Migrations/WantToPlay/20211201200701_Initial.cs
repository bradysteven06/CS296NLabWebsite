using Microsoft.EntityFrameworkCore.Migrations;

namespace CS295NTermProject.Migrations.WantToPlay
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
                    ReleaseDate = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfo", x => x.GameID);
                });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "GameID", "Name", "Platform", "ReleaseDate" },
                values: new object[] { 1, "Asteroids", "Arcade", "11/1979" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInfo");
        }
    }
}
