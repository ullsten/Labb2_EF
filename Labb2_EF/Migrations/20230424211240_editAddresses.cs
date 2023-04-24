using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class editAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FK_AddressId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Students",
                newName: "AddressesAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                newName: "IX_Students_AddressesAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressesAddressId",
                table: "Students",
                column: "AddressesAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressesAddressId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AddressesAddressId",
                table: "Students",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AddressesAddressId",
                table: "Students",
                newName: "IX_Students_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "FK_AddressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }
    }
}
