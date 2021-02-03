using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class I2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "id", "TitleDescription" },
                values: new object[] { -1, "Mrs." });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "id", "TitleDescription" },
                values: new object[] { -2, "Miss." });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "id", "TitleDescription" },
                values: new object[] { -3, "Mr." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
