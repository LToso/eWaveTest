using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWaveVolvoAPI.Migrations
{
    public partial class TruckMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    ProdYear = table.Column<int>(type: "int", nullable: false),
                    MaxLenght = table.Column<float>(type: "real", nullable: false),
                    GrossWeight = table.Column<float>(type: "real", nullable: false),
                    Axes = table.Column<int>(type: "int", nullable: false),
                    LoadCapac = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
