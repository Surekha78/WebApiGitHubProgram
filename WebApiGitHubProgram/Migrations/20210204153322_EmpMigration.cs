using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class EmpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GetEmployee1s",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetEmployee1s", x => x.id);
                    table.ForeignKey(
                        name: "FK_GetEmployee1s_job_JobID",
                        column: x => x.JobID,
                        principalTable: "job",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "JobDescription" },
                values: new object[] { -1, null });

            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "JobDescription" },
                values: new object[] { -2, null });

            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "JobDescription" },
                values: new object[] { -3, null });

            migrationBuilder.CreateIndex(
                name: "IX_GetEmployee1s_JobID",
                table: "GetEmployee1s",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetEmployee1s");

            migrationBuilder.DropTable(
                name: "job");
        }
    }
}
