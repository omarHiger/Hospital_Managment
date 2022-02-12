﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LastHMS1.Migrations
{
    public partial class AddMedical_DeatailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medical_Details",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    MD_Patient_Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    MD_Patient_Blood_Type = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    MD_Patient_Treatment_Plans_And_Daily_Supplements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Chronic_diseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Examination_Records = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Special_Needs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Family_Health_History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MD_Patient_External_Records = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Details", x => new { x.Patient_Id, x.MD_Patient_Name });
                    table.ForeignKey(
                        name: "FK_Medical_Details_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Details_Patient_Id",
                table: "Medical_Details",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Details");
        }
    }
}
