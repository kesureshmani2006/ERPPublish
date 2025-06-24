using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class propertydetails150625 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnersName = table.Column<string>(type: "text", nullable: true),
                    LessorsName = table.Column<string>(type: "text", nullable: true),
                    LessorsEmiratesId = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    LicenseNo = table.Column<string>(type: "text", nullable: true),
                    LicensingAuthority = table.Column<string>(type: "text", nullable: true),
                    rePrapertyId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandlordHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LandlordId = table.Column<long>(type: "bigint", nullable: false),
                    OwnersName = table.Column<string>(type: "text", nullable: true),
                    LessorsName = table.Column<string>(type: "text", nullable: false),
                    LessorsEmiratesId = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    LicenseNo = table.Column<string>(type: "text", nullable: false),
                    LicensingAuthority = table.Column<string>(type: "text", nullable: false),
                    rePrapertyId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReProperty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlotNo = table.Column<string>(type: "text", nullable: true),
                    MakaniNo = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    BuildingArea = table.Column<string>(type: "text", nullable: true),
                    PremisesNo = table.Column<string>(type: "text", nullable: true),
                    PropertyUsage = table.Column<string>(type: "text", nullable: true),
                    LocationLL = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RePropertyHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlotId = table.Column<long>(type: "bigint", nullable: false),
                    PlotNo = table.Column<string>(type: "text", nullable: true),
                    MakaniNo = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    BuildingArea = table.Column<string>(type: "text", nullable: true),
                    PremisesNo = table.Column<string>(type: "text", nullable: true),
                    PropertyUsage = table.Column<string>(type: "text", nullable: true),
                    LocationLL = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RePropertyHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landlord");

            migrationBuilder.DropTable(
                name: "LandlordHistory");

            migrationBuilder.DropTable(
                name: "ReProperty");

            migrationBuilder.DropTable(
                name: "RePropertyHistory");
        }
    }
}
