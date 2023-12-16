using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class Puppy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuppySessions_Enrollment_EnrollmentID",
                table: "PuppySessions");

            migrationBuilder.DropForeignKey(
                name: "FK_PuppySessions_Session_SessionId",
                table: "PuppySessions");

            migrationBuilder.DropForeignKey(
                name: "FK_PuppySessions_YogaClasses_YogaClassID",
                table: "PuppySessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuppySessions",
                table: "PuppySessions");

            migrationBuilder.RenameTable(
                name: "PuppySessions",
                newName: "PuppySession");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySessions_YogaClassID",
                table: "PuppySession",
                newName: "IX_PuppySession_YogaClassID");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySessions_SessionId",
                table: "PuppySession",
                newName: "IX_PuppySession_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySessions_EnrollmentID",
                table: "PuppySession",
                newName: "IX_PuppySession_EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuppySession",
                table: "PuppySession",
                column: "PuppySessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_Enrollment_EnrollmentID",
                table: "PuppySession",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_Session_SessionId",
                table: "PuppySession",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassID",
                table: "PuppySession",
                column: "YogaClassID",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_Enrollment_EnrollmentID",
                table: "PuppySession");

            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_Session_SessionId",
                table: "PuppySession");

            migrationBuilder.DropForeignKey(
                name: "FK_PuppySession_YogaClasses_YogaClassID",
                table: "PuppySession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuppySession",
                table: "PuppySession");

            migrationBuilder.RenameTable(
                name: "PuppySession",
                newName: "PuppySessions");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySession_YogaClassID",
                table: "PuppySessions",
                newName: "IX_PuppySessions_YogaClassID");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySession_SessionId",
                table: "PuppySessions",
                newName: "IX_PuppySessions_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_PuppySession_EnrollmentID",
                table: "PuppySessions",
                newName: "IX_PuppySessions_EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuppySessions",
                table: "PuppySessions",
                column: "PuppySessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySessions_Enrollment_EnrollmentID",
                table: "PuppySessions",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySessions_Session_SessionId",
                table: "PuppySessions",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuppySessions_YogaClasses_YogaClassID",
                table: "PuppySessions",
                column: "YogaClassID",
                principalTable: "YogaClasses",
                principalColumn: "YogaClassID");
        }
    }
}
