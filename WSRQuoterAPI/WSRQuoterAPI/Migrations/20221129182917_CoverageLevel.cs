using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class CoverageLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoveragePercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageLevels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoverageLevels",
                columns: new[] { "CoveragePercentage" },
                values: new object[] { 70 }
            );
            migrationBuilder.InsertData(
                table: "CoverageLevels",
                columns: new[] { "CoveragePercentage" },
                values: new object[] { 75 }
            );
            migrationBuilder.InsertData(
                table: "CoverageLevels",
                columns: new[] { "CoveragePercentage" },
                values: new object[] { 80 }
            );
            migrationBuilder.InsertData(
                table: "CoverageLevels",
                columns: new[] { "CoveragePercentage" },
                values: new object[] { 85 }
            );
            migrationBuilder.InsertData(
                table: "CoverageLevels",
                columns: new[] { "CoveragePercentage" },
                values: new object[] { 90 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverageLevels");
        }
    }
}
