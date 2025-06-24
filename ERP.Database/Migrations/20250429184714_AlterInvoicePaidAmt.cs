using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterInvoicePaidAmt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Invoice",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Invoice");
        }
    }
}
