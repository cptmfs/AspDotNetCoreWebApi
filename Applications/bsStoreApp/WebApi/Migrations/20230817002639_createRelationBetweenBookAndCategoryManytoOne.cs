using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class createRelationBetweenBookAndCategoryManytoOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e11f53e-de3e-4128-aa72-bc5c51438a72", "d3d4cd51-9070-481a-987c-839d4a8cfbb4", "Editor", "EDITOR" },
                    { "7d3c4915-b2e3-415e-b3fd-79033b7c6da6", "9abc4fab-f1c3-4f27-9903-9bd8c767692c", "User", "USER" },
                    { "af13ccde-98d7-47b4-8b46-cf849b05ab6d", "94f6864d-d81a-48aa-aa39-c9ac4e9dd090", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Price", "Title" },
                values: new object[] { 1, 500m, "mindshare bypass Rubber microchip" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77a841dc-8ae9-4e97-ae17-472523121e1c", "94c3bdd3-c728-4992-97eb-03e1210940f6", "Editor", "EDITOR" },
                    { "98c9d374-5b3c-40b2-8684-f9ad5ed054cf", "5b4a1e24-37f3-4b3f-bc20-d82c8ffdb686", "User", "USER" },
                    { "e429b09a-d1db-4384-9e94-5c283037854d", "5e3f8008-e571-4348-8557-88d0e03943b7", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Title" },
                values: new object[] { 65m, "İçimizdeki Şeytan" });
        }
    }
}
