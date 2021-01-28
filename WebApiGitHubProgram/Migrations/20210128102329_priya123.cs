using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class priya123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "priyatable",
                columns: table => new
                {
                    StudId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudName = table.Column<string>(maxLength: 50, nullable: false),
                    Studfee = table.Column<double>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priyatable", x => x.StudId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "priyatable");
        }
    }
}
