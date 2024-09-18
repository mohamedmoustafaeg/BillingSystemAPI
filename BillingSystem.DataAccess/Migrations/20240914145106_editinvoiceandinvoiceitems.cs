using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editinvoiceandinvoiceitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "ItemInvoices");

            migrationBuilder.AddColumn<int>(
                name: "BillsTotal",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillsTotal",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "SellingPrice",
                table: "ItemInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
