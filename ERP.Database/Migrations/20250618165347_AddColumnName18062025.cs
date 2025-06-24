using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnName18062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BulidingName",
                table: "RePropertyHistory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BulidingName",
                table: "ReProperty",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BulidingName",
                table: "RePropertyHistory");

            migrationBuilder.DropColumn(
                name: "BulidingName",
                table: "ReProperty");
        }
    }
}
