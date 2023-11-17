using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class AdjustForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId");
        }
    }
}
