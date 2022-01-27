using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurHospitalManagmentSystem.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patient_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patient_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patient_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Patient_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Patient_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Medical_Details",
                columns: table => new
                {
                    MD_Patient_Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    MD_Patient_Blood_Type = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    MD_Patient_Treatment_Plans_And_Daily_Supplements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Chronic_diseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Examination_Records = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Special_Needs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Family_Health_History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Eternal_Records = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Details", x => x.MD_Patient_Name);
                    table.ForeignKey(
                        name: "FK_Medical_Details_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Details_PatientId",
                table: "Medical_Details",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Details");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
