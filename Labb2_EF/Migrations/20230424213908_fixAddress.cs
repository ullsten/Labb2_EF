using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class fixAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_AddressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_AddressId",
                table: "Students");
        }
    }
}
