using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class I3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "id",
                keyValue: -1,
                column: "TitleDescription",
                value: "Mrs......");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "id",
                keyValue: -1,
                column: "TitleDescription",
                value: "Mrs.");
        }
    }
}
