using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class Codes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USDACodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntendedUse = table.Column<int>(nullable: true),
                    IrrigationPractice = table.Column<int>(nullable: true),
                    OrganicPractice = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USDACodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "USDACodes",
                columns: new[] { "IntendedUse", "IrrigationPractice", "OrganicPractice" },
                values: new object[] { "007", "997", "997" }
            );
            migrationBuilder.InsertData(
                table: "USDACodes",
                columns: new[] { "IntendedUse", "IrrigationPractice", "OrganicPractice" },
                values: new object[] { "030", "002", "997" }
            );
            migrationBuilder.InsertData(
                table: "USDACodes",
                columns: new[] { "IntendedUse", "IrrigationPractice", "OrganicPractice" },
                values: new object[] { "030", "003", "997" }
            );
            migrationBuilder.InsertData(
                table: "USDACodes",
                columns: new[] { "IntendedUse", "IrrigationPractice", "OrganicPractice" },
                values: new object[] { "030", "003", "001" }
            );
            migrationBuilder.InsertData(
                table: "USDACodes",
                columns: new[] { "IntendedUse", "IrrigationPractice", "OrganicPractice" },
                values: new object[] { "030", "003", "002" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USDACodes");
        }
    }
}
