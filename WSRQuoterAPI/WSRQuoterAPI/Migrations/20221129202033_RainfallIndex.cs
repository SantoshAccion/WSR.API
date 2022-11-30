using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class RainfallIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RainfallIndices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    IntervalCode = table.Column<string>(nullable: true),
                    PercentOfNormal = table.Column<double>(nullable: true),
                    IntervalMeasurement = table.Column<double>(nullable: true),
                    AverageIntervalMeasurement = table.Column<double>(nullable: true),
                    GridId = table.Column<int>(nullable: false),
                    FilingStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainfallIndices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RainfallIndices");
        }
    }
}
