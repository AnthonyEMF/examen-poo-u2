using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenPOO2.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "amortizations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interest = table.Column<int>(type: "int", nullable: false),
                    principal = table.Column<int>(type: "int", nullable: false),
                    levelpayment_without_SVSD = table.Column<int>(type: "int", nullable: false),
                    levelpayment_with_SVSD = table.Column<int>(type: "int", nullable: false),
                    principal_balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identity_number = table.Column<int>(type: "int", nullable: false),
                    loan_amount = table.Column<int>(type: "int", nullable: false),
                    commission_rate = table.Column<int>(type: "int", nullable: false),
                    interest_rate = table.Column<int>(type: "int", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursement_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amortizations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "loans",
                schema: "dbo");
        }
    }
}
