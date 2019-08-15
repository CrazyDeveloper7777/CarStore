using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class Changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber3",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber3",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VipAd_PhoneNumber2",
                table: "Ads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PhoneNumber3",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VipAd_PhoneNumber2",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }
    }
}
