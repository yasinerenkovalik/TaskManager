using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_Test_Project.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGuidToUuid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Workflows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Teams",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "TeamMembers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "TaskTags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Tasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Tags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "SubTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Files",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "Feedbacks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "ActivityLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "TaskTags");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "SubTasks");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Activate",
                table: "ActivityLogs");
        }
    }
}
