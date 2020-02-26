using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyThyme.Migrations
{
    public partial class ChangedWaterNeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaterNeedede",
                table: "Plants");

            migrationBuilder.AddColumn<double>(
                name: "WaterNeeded",
                table: "Plants",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaterNeeded",
                table: "Plants");

            migrationBuilder.AddColumn<double>(
                name: "WaterNeedede",
                table: "Plants",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
