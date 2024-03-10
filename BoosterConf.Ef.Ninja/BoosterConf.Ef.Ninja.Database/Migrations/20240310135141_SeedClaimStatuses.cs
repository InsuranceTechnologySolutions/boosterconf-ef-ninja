using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedClaimStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "insurance",
                table: "ClaimStatuses",
                columns: new[] { "Id", "Description", "ExternalId", "Name" },
                values: new object[,]
                {
                    { 1, "The claim has been submitted and is awaiting review.", new Guid("d578489e-45e0-4ff8-9ef6-5b529ed5d95c"), "Submitted" },
                    { 2, "The claim has been approved for payment.", new Guid("17fadf76-5158-4cee-a088-281761949bdf"), "Approved" },
                    { 3, "The claim has been paid to the policy holder.", new Guid("edd82f86-179a-4a41-93a7-4b204d9d1100"), "Paid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "ClaimStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "ClaimStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "ClaimStatuses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
