using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class DeleteMedical_TestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Test");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medical_Test",
                columns: table => new
                {
                    Test_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    Test_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Test_Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test_Type = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Test", x => x.Test_Id);
                    table.ForeignKey(
                        name: "FK_Medical_Test_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Test_Patient_Id",
                table: "Medical_Test",
                column: "Patient_Id");
        }
    }
}
