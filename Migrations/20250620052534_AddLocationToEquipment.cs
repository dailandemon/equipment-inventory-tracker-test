using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentInventoryTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationToEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Equipments",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Equipments",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Equipments");
        }
    }
}
