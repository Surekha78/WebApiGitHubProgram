using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class PracticeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balutable",
                columns: table => new
                {
                    StdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdName = table.Column<string>(maxLength: 50, nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balutable", x => x.StdId);
                });

            migrationBuilder.CreateTable(
                name: "MyTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balutable");

            migrationBuilder.DropTable(
                name: "MyTables");
        }
    }
}
