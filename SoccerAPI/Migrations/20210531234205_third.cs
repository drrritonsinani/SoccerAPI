using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerAPI.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "Country", "Name" },
                values: new object[,]
                {
                    { 1, null, "Premier League" },
                    { 2, null, "Seria A" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CF" },
                    { 2, "CB" },
                    { 3, "GK" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "LeagueId", "Location", "Name", "Stadium" },
                values: new object[] { 1, 1, null, "Team 1", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "LeagueId", "Location", "Name", "Stadium" },
                values: new object[] { 2, 1, null, "Team 2", null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "LeagueId", "Location", "Name", "Stadium" },
                values: new object[] { 3, 2, null, "Team 3", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 2);
        }
    }
}
