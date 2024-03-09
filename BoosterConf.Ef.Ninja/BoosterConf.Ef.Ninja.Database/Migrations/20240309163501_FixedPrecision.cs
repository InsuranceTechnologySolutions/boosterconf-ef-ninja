using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixedPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Covers_CoverEntityId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_CoverEntityId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "CoverEntityId",
                table: "Claims");

            migrationBuilder.AlterColumn<decimal>(
                name: "Premium",
                table: "Covers",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Claims",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CoverId",
                table: "Claims",
                column: "CoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Covers_CoverId",
                table: "Claims",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Covers_CoverId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_CoverId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Claims");

            migrationBuilder.AlterColumn<decimal>(
                name: "Premium",
                table: "Covers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Claims",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "CoverEntityId",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CoverEntityId",
                table: "Claims",
                column: "CoverEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Covers_CoverEntityId",
                table: "Claims",
                column: "CoverEntityId",
                principalTable: "Covers",
                principalColumn: "Id");
        }
    }
}
