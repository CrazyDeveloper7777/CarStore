using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleId",
                table: "Ads",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_VehicleId",
                table: "Ads",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Vehicles_VehicleId",
                table: "Ads",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Vehicles_VehicleId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_VehicleId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Ads");
        }
    }
}
