using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGenderFromSSN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
