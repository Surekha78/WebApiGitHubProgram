using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class Datamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataName = table.Column<string>(maxLength: 50, nullable: false),
                    Sal = table.Column<double>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyData", x => x.Id);
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
                name: "MyData");

            migrationBuilder.DropTable(
                name: "MyTables");
        }
    }
}
