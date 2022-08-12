using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    public partial class projectInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectModelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectModelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeModelProjectModel",
                columns: table => new
                {
                    UsersEmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    projectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModelProjectModel", x => new { x.UsersEmployeeId, x.projectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeModelProjectModel_Employees_UsersEmployeeId",
                        column: x => x.UsersEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeModelProjectModel_Projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModelProjectModel_projectsId",
                table: "EmployeeModelProjectModel",
                column: "projectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModelProjectModel");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectModelId",
                table: "Employees",
                column: "ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectModelId",
                table: "Employees",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
