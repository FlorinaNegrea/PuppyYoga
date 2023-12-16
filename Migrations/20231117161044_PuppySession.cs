using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuppyYoga.Migrations
{
    public partial class PuppySession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "YogaClasses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "PuppySession",
                columns: table => new
                {
                    PuppySessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YogaClassId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuppySession", x => x.PuppySessionId);
                    table.ForeignKey(
                        name: "FK_PuppySession_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuppySession_YogaClasses_YogaClassId",
                        column: x => x.YogaClassId,
                        principalTable: "YogaClasses",
                        principalColumn: "YogaClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PuppySession_SessionId",
                table: "PuppySession",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PuppySession_YogaClassId",
                table: "PuppySession",
                column: "YogaClassId");

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
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses");

            migrationBuilder.DropTable(
                name: "PuppySession");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "YogaClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_YogaClasses_Instructors_InstructorId",
                table: "YogaClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
