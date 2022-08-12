using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    public partial class updatePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModelProjectModel_Employees_UsersEmployeeId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModelProjectModel_Projects_projectsId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_UserEmployeeId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserEmployeeId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeModelProjectModel",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropColumn(
                name: "UsersEmployeeId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.RenameColumn(
                name: "UserEmployeeId",
                table: "Tasks",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "projectsId",
                table: "EmployeeModelProjectModel",
                newName: "projectsProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeModelProjectModel_projectsId",
                table: "EmployeeModelProjectModel",
                newName: "IX_EmployeeModelProjectModel_projectsProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Tasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "EmployeeModelProjectModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeModelProjectModel",
                table: "EmployeeModelProjectModel",
                columns: new[] { "UsersId", "projectsProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModelProjectModel_Employees_UsersId",
                table: "EmployeeModelProjectModel",
                column: "UsersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModelProjectModel_Projects_projectsProjectId",
                table: "EmployeeModelProjectModel",
                column: "projectsProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModelProjectModel_Employees_UsersId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeModelProjectModel_Projects_projectsProjectId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_UserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeModelProjectModel",
                table: "EmployeeModelProjectModel");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "EmployeeModelProjectModel");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "Tasks",
                newName: "UserEmployeeId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "projectsProjectId",
                table: "EmployeeModelProjectModel",
                newName: "projectsId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeModelProjectModel_projectsProjectId",
                table: "EmployeeModelProjectModel",
                newName: "IX_EmployeeModelProjectModel_projectsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "UsersEmployeeId",
                table: "EmployeeModelProjectModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeModelProjectModel",
                table: "EmployeeModelProjectModel",
                columns: new[] { "UsersEmployeeId", "projectsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserEmployeeId",
                table: "Tasks",
                column: "UserEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModelProjectModel_Employees_UsersEmployeeId",
                table: "EmployeeModelProjectModel",
                column: "UsersEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeModelProjectModel_Projects_projectsId",
                table: "EmployeeModelProjectModel",
                column: "projectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_UserEmployeeId",
                table: "Tasks",
                column: "UserEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
