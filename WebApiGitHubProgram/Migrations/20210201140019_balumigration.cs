using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class balumigration : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balutable");
        }
    }
}
