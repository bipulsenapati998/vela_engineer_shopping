using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryShopping.Migrations
{
    public partial class addrschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternetAdMobile",
                table: "addresses");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdMobile",
                table: "addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "addresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AdMobile",
                table: "addresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AlternetAdMobile",
                table: "addresses",
                nullable: true);
        }
    }
}
