using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class MarksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    English = table.Column<int>(nullable: false),
                    Maths = table.Column<int>(nullable: false),
                    Science = table.Column<int>(nullable: false),
                    Avg = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: true),
                    Grade = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markss", x => x.Id);
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
                name: "Markss");

            migrationBuilder.DropTable(
                name: "MyTables");
        }
    }
}
