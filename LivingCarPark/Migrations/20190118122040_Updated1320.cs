using Microsoft.EntityFrameworkCore.Migrations;

namespace LivingCarPark.Migrations
{
    public partial class Updated1320 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carparks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carparks_UserId",
                table: "Carparks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carparks_AspNetUsers_UserId",
                table: "Carparks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carparks_AspNetUsers_UserId",
                table: "Carparks");

            migrationBuilder.DropIndex(
                name: "IX_Carparks_UserId",
                table: "Carparks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carparks");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
