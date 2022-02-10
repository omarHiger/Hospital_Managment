using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LastHMS.Migrations
{
    public partial class AddMedical_TestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medical_Tests",
                columns: table => new
                {
                    Test_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Test_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Test_Type = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Test_Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Tests", x => x.Test_Id);
                    table.ForeignKey(
                        name: "FK_Medical_Tests_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Tests_Patient_Id",
                table: "Medical_Tests",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Tests");
        }
    }
}
