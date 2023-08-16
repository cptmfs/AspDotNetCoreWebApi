using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56250737-9c82-4023-a876-acf3afaf4bef", "02b038f0-c882-4326-bc17-3b8cbb45fe57", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5b6d28e-dc0a-411d-81ce-9eb369f872aa", "c28bd409-8fba-494e-9de3-37f471d951a3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5758830-877d-4e0e-bfc5-dda65c8cbe66", "473d4ab2-37f8-4b33-a1f3-b92b022bfbf2", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56250737-9c82-4023-a876-acf3afaf4bef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5b6d28e-dc0a-411d-81ce-9eb369f872aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5758830-877d-4e0e-bfc5-dda65c8cbe66");
        }
    }
}
