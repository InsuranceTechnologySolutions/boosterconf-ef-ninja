using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class SpecifySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "insurance");

            migrationBuilder.EnsureSchema(
                name: "pii");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "pii");

            migrationBuilder.RenameTable(
                name: "CustomerAddresses",
                newName: "CustomerAddresses",
                newSchema: "pii");

            migrationBuilder.RenameTable(
                name: "CoverTypes",
                newName: "CoverTypes",
                newSchema: "insurance");

            migrationBuilder.RenameTable(
                name: "Covers",
                newName: "Covers",
                newSchema: "insurance");

            migrationBuilder.RenameTable(
                name: "ClaimStatuses",
                newName: "ClaimStatuses",
                newSchema: "insurance");

            migrationBuilder.RenameTable(
                name: "Claims",
                newName: "Claims",
                newSchema: "insurance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "pii",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CustomerAddresses",
                schema: "pii",
                newName: "CustomerAddresses");

            migrationBuilder.RenameTable(
                name: "CoverTypes",
                schema: "insurance",
                newName: "CoverTypes");

            migrationBuilder.RenameTable(
                name: "Covers",
                schema: "insurance",
                newName: "Covers");

            migrationBuilder.RenameTable(
                name: "ClaimStatuses",
                schema: "insurance",
                newName: "ClaimStatuses");

            migrationBuilder.RenameTable(
                name: "Claims",
                schema: "insurance",
                newName: "Claims");
        }
    }
}
