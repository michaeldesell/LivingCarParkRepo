using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParkApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amountofcars",
                table: "Carparks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "carpark_rating",
                table: "Carparks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "develop_pressure",
                table: "Carparks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amountofcars",
                table: "Carparks");

            migrationBuilder.DropColumn(
                name: "carpark_rating",
                table: "Carparks");

            migrationBuilder.DropColumn(
                name: "develop_pressure",
                table: "Carparks");
        }
    }
}
