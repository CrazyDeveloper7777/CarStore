using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_AspNetUsers_DealerId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Vehicles_BusId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Vehicles_CarId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Vehicles_MotorcycleId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Vehicles_TruckId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ad_AdId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ad",
                table: "Ad");

            migrationBuilder.RenameTable(
                name: "Ad",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_TruckId",
                table: "Ads",
                newName: "IX_Ads_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_MotorcycleId",
                table: "Ads",
                newName: "IX_Ads_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_CarId",
                table: "Ads",
                newName: "IX_Ads_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_BusId",
                table: "Ads",
                newName: "IX_Ads_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_IsDeleted",
                table: "Ads",
                newName: "IX_Ads_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_DealerId",
                table: "Ads",
                newName: "IX_Ads_DealerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_DealerId",
                table: "Ads",
                column: "DealerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Vehicles_BusId",
                table: "Ads",
                column: "BusId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Vehicles_CarId",
                table: "Ads",
                column: "CarId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Vehicles_MotorcycleId",
                table: "Ads",
                column: "MotorcycleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Vehicles_TruckId",
                table: "Ads",
                column: "TruckId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdId",
                table: "Images",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_DealerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Vehicles_BusId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Vehicles_CarId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Vehicles_MotorcycleId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Vehicles_TruckId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Ad");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_TruckId",
                table: "Ad",
                newName: "IX_Ad_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_MotorcycleId",
                table: "Ad",
                newName: "IX_Ad_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CarId",
                table: "Ad",
                newName: "IX_Ad_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_BusId",
                table: "Ad",
                newName: "IX_Ad_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_IsDeleted",
                table: "Ad",
                newName: "IX_Ad_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_DealerId",
                table: "Ad",
                newName: "IX_Ad_DealerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ad",
                table: "Ad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_AspNetUsers_DealerId",
                table: "Ad",
                column: "DealerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Vehicles_BusId",
                table: "Ad",
                column: "BusId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Vehicles_CarId",
                table: "Ad",
                column: "CarId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Vehicles_MotorcycleId",
                table: "Ad",
                column: "MotorcycleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Vehicles_TruckId",
                table: "Ad",
                column: "TruckId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ad_AdId",
                table: "Images",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
