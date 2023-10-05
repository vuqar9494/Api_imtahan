using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_EXAM.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LESSONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSTRUCTOR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSTRUCTOR_SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CLASS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LESSONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CLASS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXAMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LESSON_ID = table.Column<int>(type: "int", nullable: false),
                    STUDENT_ID = table.Column<int>(type: "int", nullable: false),
                    POINT = table.Column<int>(type: "int", nullable: true),
                    EXAM_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXAMS_LESSONS_LESSON_ID",
                        column: x => x.LESSON_ID,
                        principalTable: "LESSONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAMS_STUDENTS_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXAMS_LESSON_ID",
                table: "EXAMS",
                column: "LESSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAMS_STUDENT_ID",
                table: "EXAMS",
                column: "STUDENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXAMS");

            migrationBuilder.DropTable(
                name: "LESSONS");

            migrationBuilder.DropTable(
                name: "STUDENTS");
        }
    }
}
