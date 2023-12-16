using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollment_YogaClassID",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentID",
                table: "YogaClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_YogaClassID",
                table: "Enrollment",
                column: "YogaClassID",
                unique: true,
                filter: "[YogaClassID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enrollment_YogaClassID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "EnrollmentID",
                table: "YogaClasses");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "User",
                newName: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_YogaClassID",
                table: "Enrollment",
                column: "YogaClassID");
        }
    }
}
