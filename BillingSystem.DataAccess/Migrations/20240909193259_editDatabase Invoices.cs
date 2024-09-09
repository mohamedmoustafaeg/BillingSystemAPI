using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editDatabaseInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Invoices",
                newName: "Net");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ItemInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellingPrice",
                table: "ItemInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "ItemInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Name",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemInvoices");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "ItemInvoices");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ItemInvoices");

            migrationBuilder.RenameColumn(
                name: "Net",
                table: "Invoices",
                newName: "TotalValue");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
