using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class CreateYogaClassesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_YogaClass_YogaClassID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_YogaClass_YogaClassID",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaClass_Instructor_InstructorId",
                table: "YogaClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YogaClass",
                table: "YogaClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "YogaClass",
                newName: "YogaClasses");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameIndex(
                name: "IX_YogaClass_InstructorId",
                table: "YogaClasses",
                newName: "IX_YogaClasses_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YogaClasses",
                table: "YogaClasses",
                column: "YogaClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_YogaClasses_YogaClassID",
                table: "Enrollment",
                column: "YogaClassID",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_YogaClasses_YogaClassID",
                table: "Feedback",
                column: "YogaClassID",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_YogaClasses_YogaClassID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_YogaClasses_YogaClassID",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YogaClasses",
                table: "YogaClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "YogaClasses",
                newName: "YogaClass");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_YogaClasses_InstructorId",
                table: "YogaClass",
                newName: "IX_YogaClass_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YogaClass",
                table: "YogaClass",
                column: "YogaClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_YogaClass_YogaClassID",
                table: "Enrollment",
                column: "YogaClassID",
                principalTable: "YogaClass",
                principalColumn: "YogaClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_YogaClass_YogaClassID",
                table: "Feedback",
                column: "YogaClassID",
                principalTable: "YogaClass",
                principalColumn: "YogaClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClass_Instructor_InstructorId",
                table: "YogaClass",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId");
        }
    }
}
