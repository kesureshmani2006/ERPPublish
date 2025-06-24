using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNoAddinproperty21062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyNo",
                table: "ReProperty",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyNo",
                table: "ReProperty");
        }
    }
}
