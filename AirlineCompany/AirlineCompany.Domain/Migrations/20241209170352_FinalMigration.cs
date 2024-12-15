using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_passengers_id_flight",
                table: "passengers",
                column: "id_flight");

            migrationBuilder.AddForeignKey(
                name: "FK_passengers_passengers_id_flight",
                table: "passengers",
                column: "id_flight",
                principalTable: "passengers",
                principalColumn: "id_passenger",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passengers_passengers_id_flight",
                table: "passengers");

            migrationBuilder.DropIndex(
                name: "IX_passengers_id_flight",
                table: "passengers");
        }
    }
}
