using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyName18062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingArea",
                table: "RePropertyHistory",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "BuildingArea",
                table: "ReProperty",
                newName: "PropertyType");

            migrationBuilder.AddColumn<string>(
                name: "PropertyArea",
                table: "RePropertyHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyArea",
                table: "ReProperty",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyArea",
                table: "RePropertyHistory");

            migrationBuilder.DropColumn(
                name: "PropertyArea",
                table: "ReProperty");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "RePropertyHistory",
                newName: "BuildingArea");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "ReProperty",
                newName: "BuildingArea");
        }
    }
}
