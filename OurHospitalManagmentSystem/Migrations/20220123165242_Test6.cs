using Microsoft.EntityFrameworkCore.Migrations;

namespace OurHospitalManagmentSystem.Migrations
{
    public partial class Test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Details");

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

            migrationBuilder.CreateTable(
                name: "Medical_Details",
                columns: table => new
                {
                    MD_Patient_Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    MD_Patient_Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Blood_Type = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    MD_Patient_Chronic_diseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Eternal_Records = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Examination_Records = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Family_Health_History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Special_Needs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Treatment_Plans_And_Daily_Supplements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Details", x => x.MD_Patient_Name);
                    table.ForeignKey(
                        name: "FK_Medical_Details_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Details_Patient_Id",
                table: "Medical_Details",
                column: "Patient_Id");
        }
    }
}
