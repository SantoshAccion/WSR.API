using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class CountyBaseValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountyBaseValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseValue = table.Column<double>(nullable: false),
                    IntendedUse = table.Column<string>(nullable: true),
                    IrrigationPractice = table.Column<string>(nullable: true),
                    OrganicPractice = table.Column<string>(nullable: true),
                    StateCode = table.Column<string>(nullable: true),
                    CountyCode = table.Column<string>(nullable: true),
                    SampleYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyBaseValues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountyBaseValues");
        }
    }
}
