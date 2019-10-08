using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryShopping.Migrations
{
    public partial class rmvAddresstype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_addressType_AddressTypeID",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_addresses_AddressTypeID",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "AddressTypeID",
                table: "addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressTypeID",
                table: "addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_AddressTypeID",
                table: "addresses",
                column: "AddressTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_addressType_AddressTypeID",
                table: "addresses",
                column: "AddressTypeID",
                principalTable: "addressType",
                principalColumn: "AddressTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
