using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyThyme.Migrations
{
    public partial class ChangedWaterNeededToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WaterNeeded",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WaterNeeded",
                table: "Plants",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
