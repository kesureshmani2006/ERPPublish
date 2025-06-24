using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class tenantpropertyid21062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "ReTenants",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "ReContracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "ReTenants");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "ReContracts");
        }
    }
}
