using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e11f53e-de3e-4128-aa72-bc5c51438a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d3c4915-b2e3-415e-b3fd-79033b7c6da6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af13ccde-98d7-47b4-8b46-cf849b05ab6d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30e66bc9-8642-41d3-9753-c753c851124a", "b9f18b87-4c41-4bf6-a71c-4792ec74549b", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c142b90-c39e-443b-a399-882dd2ab05e0", "d515d4fb-aabb-49ad-90ed-9c9dbf1f566e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e39e5dd8-5e1b-4eff-b365-40c81cf1a791", "cbb46e08-0e9e-4285-ba2d-d34b88cc3dc5", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30e66bc9-8642-41d3-9753-c753c851124a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c142b90-c39e-443b-a399-882dd2ab05e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39e5dd8-5e1b-4eff-b365-40c81cf1a791");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e11f53e-de3e-4128-aa72-bc5c51438a72", "d3d4cd51-9070-481a-987c-839d4a8cfbb4", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d3c4915-b2e3-415e-b3fd-79033b7c6da6", "9abc4fab-f1c3-4f27-9903-9bd8c767692c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af13ccde-98d7-47b4-8b46-cf849b05ab6d", "94f6864d-d81a-48aa-aa39-c9ac4e9dd090", "Admin", "ADMIN" });
        }
    }
}
