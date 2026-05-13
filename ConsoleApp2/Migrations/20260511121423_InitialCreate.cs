using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "task");

            migrationBuilder.RenameTable(
                name: "Teachers",
                schema: "public",
                newName: "Teachers",
                newSchema: "task");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "public",
                newName: "Students",
                newSchema: "task");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                schema: "public",
                newName: "Enrollments",
                newSchema: "task");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "public",
                newName: "Courses",
                newSchema: "task");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Teachers",
                schema: "task",
                newName: "Teachers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "task",
                newName: "Students",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                schema: "task",
                newName: "Enrollments",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "task",
                newName: "Courses",
                newSchema: "public");
        }
    }
}
