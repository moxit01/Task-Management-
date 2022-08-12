using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    public partial class updateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Employees_UserEmployeeId",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Projects_ProjectId",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_UserEmployeeId",
                table: "Tasks",
                newName: "IX_Tasks_UserEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_UserEmployeeId",
                table: "Tasks",
                column: "UserEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_UserEmployeeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserEmployeeId",
                table: "tasks",
                newName: "IX_tasks_UserEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "tasks",
                newName: "IX_tasks_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Employees_UserEmployeeId",
                table: "tasks",
                column: "UserEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Projects_ProjectId",
                table: "tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
