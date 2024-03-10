using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class ClaimsTpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoClaims",
                schema: "insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AccidentReport = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RepairEstimate = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoClaims_Claims_Id",
                        column: x => x.Id,
                        principalSchema: "insurance",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LifeClaims",
                schema: "insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PolicyHolderName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DeathCertificate = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LifeClaims_Claims_Id",
                        column: x => x.Id,
                        principalSchema: "insurance",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiscClaims",
                schema: "insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiscClaims_Claims_Id",
                        column: x => x.Id,
                        principalSchema: "insurance",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoClaims",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "LifeClaims",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "MiscClaims",
                schema: "insurance");
        }
    }
}
