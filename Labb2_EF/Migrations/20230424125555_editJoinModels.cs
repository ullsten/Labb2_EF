using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class editJoinModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Teachers_TeacherId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_TeacherId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Enrollments");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_TeacherId",
                table: "StudentCourse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_FK_TeacherId",
                table: "StudentCourse",
                column: "FK_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FK_TeacherId",
                table: "Enrollments",
                column: "FK_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Teachers_FK_TeacherId",
                table: "Enrollments",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Teachers_FK_TeacherId",
                table: "StudentCourse",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Teachers_FK_TeacherId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Teachers_FK_TeacherId",
                table: "StudentCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_FK_TeacherId",
                table: "StudentCourse");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_FK_TeacherId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FK_TeacherId",
                table: "StudentCourse");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Enrollments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TeacherId",
                table: "Enrollments",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Teachers_TeacherId",
                table: "Enrollments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }
    }
}
