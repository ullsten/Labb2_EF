using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class editStudT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_FK_AddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FK_AddressId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_AddressId",
                table: "Students",
                column: "FK_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_FK_AddressId",
                table: "Students",
                column: "FK_AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
