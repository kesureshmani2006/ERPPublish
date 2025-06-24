using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP.Database.Migrations
{
    /// <inheritdoc />
    public partial class trenantandchequedetails19062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReCheque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChequeNo = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    ChequeDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ChequeAmount = table.Column<double>(type: "double precision", nullable: false),
                    ChqStatus = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReCheque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReContracts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    ContractFromDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ContractToDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ContractDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AnnualRent = table.Column<double>(type: "double precision", nullable: false),
                    ContractRent = table.Column<double>(type: "double precision", nullable: false),
                    SecurityDepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    ModeOfPayment = table.Column<string>(type: "text", nullable: true),
                    ContractStatus = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReTenants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantName = table.Column<string>(type: "text", nullable: false),
                    TenantEmiratedId = table.Column<string>(type: "text", nullable: true),
                    TenantPhone = table.Column<string>(type: "text", nullable: true),
                    TenantEmail = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReTenants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReCheque");

            migrationBuilder.DropTable(
                name: "ReContracts");

            migrationBuilder.DropTable(
                name: "ReTenants");
        }
    }
}
