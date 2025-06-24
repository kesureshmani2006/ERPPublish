using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterPOItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PurchaseRequestItemId",
                table: "PurchaseOrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseRequestItemId",
                table: "PurchaseOrderItems",
                column: "PurchaseRequestItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_PurchaseRequestItems_PurchaseRequestItem~",
                table: "PurchaseOrderItems",
                column: "PurchaseRequestItemId",
                principalTable: "PurchaseRequestItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_PurchaseRequestItems_PurchaseRequestItem~",
                table: "PurchaseOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderItems_PurchaseRequestItemId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "PurchaseRequestItemId",
                table: "PurchaseOrderItems");
        }
    }
}
