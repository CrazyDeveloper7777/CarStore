using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class Changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopulatedPlace",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PopulatedPlace",
                table: "Ads",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Ads",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PopulatedPlace",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "PopulatedPlace",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }
    }
}
