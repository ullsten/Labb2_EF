using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class whoot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_FK_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_FK_StudentId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Teachers_FK_TeacherId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentTeachersCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_FK_TeacherId",
                table: "StudentTeachersCourses",
                newName: "IX_StudentTeachersCourses_FK_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_FK_StudentId",
                table: "StudentTeachersCourses",
                newName: "IX_StudentTeachersCourses_FK_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_FK_CourseId",
                table: "StudentTeachersCourses",
                newName: "IX_StudentTeachersCourses_FK_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeachersCourses",
                table: "StudentTeachersCourses",
                column: "StudentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachersCourses_Courses_FK_CourseId",
                table: "StudentTeachersCourses",
                column: "FK_CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachersCourses_Students_FK_StudentId",
                table: "StudentTeachersCourses",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachersCourses_Teachers_FK_TeacherId",
                table: "StudentTeachersCourses",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachersCourses_Courses_FK_CourseId",
                table: "StudentTeachersCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachersCourses_Students_FK_StudentId",
                table: "StudentTeachersCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachersCourses_Teachers_FK_TeacherId",
                table: "StudentTeachersCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeachersCourses",
                table: "StudentTeachersCourses");

            migrationBuilder.RenameTable(
                name: "StudentTeachersCourses",
                newName: "StudentCourse");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTeachersCourses_FK_TeacherId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_FK_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTeachersCourses_FK_StudentId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_FK_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentTeachersCourses_FK_CourseId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_FK_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                column: "StudentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_FK_CourseId",
                table: "StudentCourse",
                column: "FK_CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_FK_StudentId",
                table: "StudentCourse",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Teachers_FK_TeacherId",
                table: "StudentCourse",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
