using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgeFromSSN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: true);
        }
    }
}
