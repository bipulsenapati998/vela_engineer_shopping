using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryShopping.Migrations
{
    public partial class myOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "myOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrderedQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_myOrders_Products_PId",
                        column: x => x.PId,
                        principalTable: "Products",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_myOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_myOrders_PId",
                table: "myOrders",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_myOrders_UserId",
                table: "myOrders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myOrders");
        }
    }
}
