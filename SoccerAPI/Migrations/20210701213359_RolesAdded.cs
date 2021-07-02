using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerAPI.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "896d41d9-e9c6-42b3-b212-a43ba2e7bc19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec778d1f-8e7e-416d-84ff-f61ae502a20f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c28be5de-a22e-4525-b655-313b0df6a357", "dd19ba53-ba5c-4b35-954d-17caa9a390e7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33efc7c2-955c-490b-b8f2-d01daa439fb9", "4dcb4ce2-5f80-4c27-8336-a43508f51682", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33efc7c2-955c-490b-b8f2-d01daa439fb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28be5de-a22e-4525-b655-313b0df6a357");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "896d41d9-e9c6-42b3-b212-a43ba2e7bc19", "309e4685-69d0-43a5-9c8d-3f0f39bcede4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec778d1f-8e7e-416d-84ff-f61ae502a20f", "b72f7e0a-1f84-4300-b378-095315882cf2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
