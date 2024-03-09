using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class CustomerIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName_LastName",
                table: "Customers",
                columns: new[] { "FirstName", "LastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_FirstName_LastName",
                table: "Customers");
        }
    }
}
