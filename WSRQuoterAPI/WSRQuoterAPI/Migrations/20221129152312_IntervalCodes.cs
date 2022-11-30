using Microsoft.EntityFrameworkCore.Migrations;

namespace WSRQuoterAPI.Migrations
{
    public partial class IntervalCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntervalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Months = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervalCodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "625", "JAN-FEB" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "626", "FEB-MAR" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "627", "MAR-APR" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "628", "APR-MAY" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "629", "MAY-JUN" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "630", "JUN-JUL" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "631", "JUL-AUG" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "632", "AUG-SEP" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "633", "SEP-OCT" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "634", "OCT-NOV" }
            );
            migrationBuilder.InsertData(
                table: "IntervalCodes",
                columns: new[] { "Code", "Months" },
                values: new object[] { "635", "NOV-DEC" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntervalCodes");
        }
    }
}
