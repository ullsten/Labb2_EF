using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_EF.Migrations
{
    /// <inheritdoc />
    public partial class addedAddresss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_FK_AddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Address_AddressesAddressId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_FK_AddressId",
                table: "Students",
                column: "FK_AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Addresses_AddressesAddressId",
                table: "Teachers",
                column: "AddressesAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_FK_AddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Addresses_AddressesAddressId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_FK_AddressId",
                table: "Students",
                column: "FK_AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Address_AddressesAddressId",
                table: "Teachers",
                column: "AddressesAddressId",
                principalTable: "Address",
                principalColumn: "AddressId");
        }
    }
}
