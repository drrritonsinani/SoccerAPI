using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerAPI.Migrations
{
    public partial class fourthdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "asd");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "fgh");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "dfg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "CF");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "CB");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "GK");
        }
    }
}
