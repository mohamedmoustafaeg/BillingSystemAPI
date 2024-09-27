using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateinvoiceandunits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaidUp",
                table: "Invoices",
                newName: "BillNumber");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Units",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellingPrice",
                table: "ItemInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "ItemInvoices");

            migrationBuilder.RenameColumn(
                name: "BillNumber",
                table: "Invoices",
                newName: "PaidUp");
        }
    }
}
