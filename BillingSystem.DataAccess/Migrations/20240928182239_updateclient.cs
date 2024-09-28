using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Clients");
        }
    }
}
