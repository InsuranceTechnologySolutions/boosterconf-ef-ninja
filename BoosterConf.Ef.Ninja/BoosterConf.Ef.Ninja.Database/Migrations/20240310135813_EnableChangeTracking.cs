using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoosterConf.Ef.Ninja.Database.Migrations
{
    /// <inheritdoc />
    public partial class EnableChangeTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // We have scaffolded an empty migration to run some custom SQL
            migrationBuilder.Sql(
                """
                    ALTER DATABASE EfNinja
                    SET CHANGE_TRACKING = ON
                    (CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON);
                """,
                suppressTransaction: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Don't forget to implement the `Down` part of the migration
            // In case you need to roll your changes back.
            migrationBuilder.Sql(
                """
                    ALTER DATABASE EfNinja
                    SET CHANGE_TRACKING = OFF;
                """,
                suppressTransaction: true
            );
        }
    }
}
