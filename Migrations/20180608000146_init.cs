using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStarter.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrewerType",
                columns: table => new
                {
                    BrewerTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Recipe_WaterTemperatureF = table.Column<int>(nullable: false),
                    Recipe_GrindSize = table.Column<int>(nullable: false),
                    Recipe_GrindOunces = table.Column<int>(nullable: false),
                    Recipe_WaterOunces = table.Column<int>(nullable: false),
                    Recipe_BrewTime = table.Column<int>(nullable: false),
                    Recipe_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewerType", x => x.BrewerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetAddress = table.Column<string>(nullable: true),
                    OpenTime = table.Column<string>(nullable: true),
                    CloseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationId = table.Column<int>(nullable: false),
                    BrewerTypeId = table.Column<int>(nullable: false),
                    Acquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Unit_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 1, "4PM", "6AM", null });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "UnitId", "Acquired", "BrewerTypeId", "LocationId" },
                values: new object[] { 1, new DateTime(2018, 6, 7, 20, 1, 46, 66, DateTimeKind.Local), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Unit_LocationId",
                table: "Unit",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewerType");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
