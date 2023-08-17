using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CreateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6105e9c8-5c95-447d-8657-b1309eb2e075");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf28d2e-c6f6-4059-bf3a-d1e0b6c08813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3f138f7-e812-4e07-8b75-56553efda775");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77a841dc-8ae9-4e97-ae17-472523121e1c", "94c3bdd3-c728-4992-97eb-03e1210940f6", "Editor", "EDITOR" },
                    { "98c9d374-5b3c-40b2-8684-f9ad5ed054cf", "5b4a1e24-37f3-4b3f-bc20-d82c8ffdb686", "User", "USER" },
                    { "e429b09a-d1db-4384-9e94-5c283037854d", "5e3f8008-e571-4348-8557-88d0e03943b7", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database Management System" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77a841dc-8ae9-4e97-ae17-472523121e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98c9d374-5b3c-40b2-8684-f9ad5ed054cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e429b09a-d1db-4384-9e94-5c283037854d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6105e9c8-5c95-447d-8657-b1309eb2e075", "b42a1b2e-8696-4111-8fa2-52c3853b9827", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caf28d2e-c6f6-4059-bf3a-d1e0b6c08813", "e9cab3f2-cadf-4721-b2d8-543499aedd36", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3f138f7-e812-4e07-8b75-56553efda775", "93c9112b-b38a-40c1-9f92-a66139c1d9aa", "User", "USER" });
        }
    }
}
