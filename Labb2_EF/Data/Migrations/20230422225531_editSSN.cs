using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class editSSN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SSN",
                table: "Student",
                newName: "PersonalNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Student",
                newName: "SSN");
        }
    }
}
