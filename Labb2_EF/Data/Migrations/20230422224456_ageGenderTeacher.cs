using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class ageGenderTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "Teacher");
        }
    }
}
