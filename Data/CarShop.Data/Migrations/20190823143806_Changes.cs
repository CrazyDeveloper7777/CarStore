using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Truck_AxlesCount",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Truck_LoadInKg",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Truck_SeatsCount",
                table: "Vehicles",
                newName: "DoorsCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoorsCount",
                table: "Vehicles",
                newName: "Truck_SeatsCount");

            migrationBuilder.AddColumn<int>(
                name: "Truck_AxlesCount",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Truck_LoadInKg",
                table: "Vehicles",
                nullable: true);
        }
    }
}
