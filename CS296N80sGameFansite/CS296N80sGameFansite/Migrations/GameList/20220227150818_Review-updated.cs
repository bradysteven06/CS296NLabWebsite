using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS296N80sGameFansite.Migrations.GameList
{
    public partial class Reviewupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "A", 0, "0ce92b50-d8b6-48db-95d5-b6556afd3985", null, false, false, null, "Steven Brady", null, null, null, null, false, "46753597-0bf3-4e6f-8f08-a453f1975a43", false, "StevenB" },
                    { "B", 0, "9b813130-e172-4904-9604-8df53a1f8413", null, false, false, null, "Emma Watson", null, null, null, null, false, "7faf4e28-2712-49de-afbe-4af8becb9ea4", false, "EmmaW" },
                    { "C", 0, "c3d4f00a-cf0c-4ff6-bc08-8b2e838c656c", null, false, false, null, "Daniel Radcliffe", null, null, null, null, false, "97b19175-7971-4554-96ca-295b7653b0b6", false, "DanielR" },
                    { "D", 0, "6ad1ff99-bcd5-4347-9612-4b7a5d550d6e", null, false, false, null, "Scarlett Johansson", null, null, null, null, false, "d0e1227e-d35c-410e-b754-904955c9e517", false, "ScarlettJ" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "GameName", "Genre", "Rating", "ReviewDate", "ReviewText", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "Tetris", "Puzzle", 5, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great game, a must play!", "A" },
                    { 4, "Donkey Kong", "Platformer", 4, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great game, a must play!", "B" },
                    { 2, "Pacman", "Platform", 5, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great game, a must play!", "C" },
                    { 3, "Tetris", "Puzzle", 5, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great game, a must play!", "D" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentDate", "CommentText", "CommenterId", "ReviewId" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "So nostalgic", "B", 1 },
                    { 4, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lots of fun.", "B", 4 },
                    { 2, new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great game.", "C", 2 },
                    { 5, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can't stop playing.", "A", 2 },
                    { 1, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "I loved that game too!", "A", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D");
        }
    }
}
