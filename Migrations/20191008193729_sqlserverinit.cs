using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStarter.Migrations
{
    public partial class sqlserverinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 999, "4PM", "6AM", "999 Main Street" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 999);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 1, "4PM", "6AM", "999 Main Street" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 2, "4PM", "6AM", "2 Main Street" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { 3, "4PM", "6AM", "3 Main Street" });
        }
    }
}
