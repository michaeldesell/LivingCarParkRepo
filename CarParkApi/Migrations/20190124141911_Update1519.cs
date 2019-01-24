using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParkApi.Migrations
{
    public partial class Update1519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Floors",
                table: "Carparks",
                newName: "SpacesperFloor");

            migrationBuilder.RenameColumn(
                name: "Amountofcars",
                table: "Carparks",
                newName: "Carsleaving");

            migrationBuilder.AddColumn<int>(
                name: "Amountparkedcars",
                table: "Carparks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Carsarriving",
                table: "Carparks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Floornumber = table.Column<int>(nullable: false),
                    spaces = table.Column<int>(nullable: false),
                    CarparkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Carparks_CarparkId",
                        column: x => x.CarparkId,
                        principalTable: "Carparks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parkingspace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParkedcarId = table.Column<int>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    FloorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkingspace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkingspace_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parkingspace_Car_ParkedcarId",
                        column: x => x.ParkedcarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floor_CarparkId",
                table: "Floor",
                column: "CarparkId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkingspace_FloorId",
                table: "Parkingspace",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkingspace_ParkedcarId",
                table: "Parkingspace",
                column: "ParkedcarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parkingspace");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropColumn(
                name: "Amountparkedcars",
                table: "Carparks");

            migrationBuilder.DropColumn(
                name: "Carsarriving",
                table: "Carparks");

            migrationBuilder.RenameColumn(
                name: "SpacesperFloor",
                table: "Carparks",
                newName: "Floors");

            migrationBuilder.RenameColumn(
                name: "Carsleaving",
                table: "Carparks",
                newName: "Amountofcars");
        }
    }
}
