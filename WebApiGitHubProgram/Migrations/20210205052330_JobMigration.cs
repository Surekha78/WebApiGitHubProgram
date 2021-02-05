using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class JobMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "job",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -3,
                column: "JobDescription",
                value: "Dev.");

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -2,
                column: "JobDescription",
                value: "Admin.");

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -1,
                column: "JobDescription",
                value: "HR......");

            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "JobDescription" },
                values: new object[] { -4, "Hr." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -3,
                column: "JobDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -2,
                column: "JobDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "job",
                keyColumn: "id",
                keyValue: -1,
                column: "JobDescription",
                value: null);
        }
    }
}
