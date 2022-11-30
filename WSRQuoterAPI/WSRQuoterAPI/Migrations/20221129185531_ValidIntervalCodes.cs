using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class ValidIntervalCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValidIntervalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntendedUse = table.Column<string>(nullable: true),
                    IrrigationPractice = table.Column<string>(nullable: true),
                    OrganicPractice = table.Column<string>(nullable: true),
                    StateCode = table.Column<string>(nullable: true),
                    CountyCode = table.Column<string>(nullable: true),
                    GridId = table.Column<string>(nullable: true),
                    CoveragePercentage = table.Column<int>(nullable: true),
                    IntervalCode = table.Column<string>(nullable: true),
                    PremiumRate = table.Column<double>(nullable: false),
                    IntervalIsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidIntervalCodes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidIntervalCodes");
        }
    }
}
