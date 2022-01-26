using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddPatientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111111, 1"),
                    Patient_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Patient_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patient_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_X_Y = table.Column<string>(type: "nvarchar(61)", maxLength: 61, nullable: false),
                    Patient_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patient_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Patient_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Patient_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ho_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Phone_Numbers",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    Patient_Phone_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Phone_Numbers", x => new { x.Patient_Id, x.Patient_Phone_Number });
                    table.ForeignKey(
                        name: "FK_Patient_Phone_Numbers_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
