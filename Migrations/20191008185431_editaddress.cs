using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStarter.Migrations
{
    public partial class editaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "UnitId",
                keyValue: 1);
            
            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                column: "StreetAddress",
                value: "999 Main Street");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 2, "4PM", "6AM", "2 Main Street" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 3, "4PM", "6AM", "3 Main Street" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Locations_LocationId",
                table: "Unit");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BrewerType",
                columns: table => new
                {
                    BrewerTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Recipe_BrewTime = table.Column<int>(nullable: false),
                    Recipe_Description = table.Column<string>(nullable: true),
                    Recipe_GrindOunces = table.Column<int>(nullable: false),
                    Recipe_GrindSize = table.Column<int>(nullable: false),
                    Recipe_WaterOunces = table.Column<int>(nullable: false),
                    Recipe_WaterTemperatureF = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewerType", x => x.BrewerTypeId);
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1,
                column: "StreetAddress",
                value: null);

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "UnitId", "Acquired", "BrewerTypeId", "LocationId" },
                values: new object[] { 1, new DateTime(2018, 6, 7, 20, 1, 46, 66, DateTimeKind.Local), 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Locations_LocationId",
                table: "Unit",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
