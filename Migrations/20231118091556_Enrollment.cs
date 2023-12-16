using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class Enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassId",
                table: "PuppySession");

            migrationBuilder.RenameColumn(
                name: "YogaClassId",
                table: "PuppySession",
                newName: "YogaClassID");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySession_YogaClassId",
                table: "PuppySession",
                newName: "IX_PuppySession_YogaClassID");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentID",
                table: "PuppySession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PuppySession_EnrollmentID",
                table: "PuppySession",
                column: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_Enrollment_EnrollmentID",
                table: "PuppySession",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassID",
                table: "PuppySession",
                column: "YogaClassID",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_Enrollment_EnrollmentID",
                table: "PuppySession");

            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassID",
                table: "PuppySession");

            migrationBuilder.DropIndex(
                name: "IX_PuppySession_EnrollmentID",
                table: "PuppySession");

            migrationBuilder.DropColumn(
                name: "EnrollmentID",
                table: "PuppySession");

            migrationBuilder.RenameColumn(
                name: "YogaClassID",
                table: "PuppySession",
                newName: "YogaClassId");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySession_YogaClassID",
                table: "PuppySession",
                newName: "IX_PuppySession_YogaClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassId",
                table: "PuppySession",
                column: "YogaClassId",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
