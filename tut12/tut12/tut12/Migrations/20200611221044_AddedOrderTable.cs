using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tut12.Migrations
{
    public partial class AddedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "date", nullable: false),
                    DateFinished = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pk", x => x.IdOrder);
                    table.ForeignKey(
                        name: "idCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "idEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomer",
                table: "Order",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                table: "Order",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
