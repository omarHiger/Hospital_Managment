using Microsoft.EntityFrameworkCore.Migrations;

namespace OurHospitalManagmentSystem.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Details_Patients_PatientId",
                table: "Medical_Details");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Medical_Details",
                newName: "Patient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Medical_Details_PatientId",
                table: "Medical_Details",
                newName: "IX_Medical_Details_Patient_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Details_Patients_Patient_Id",
                table: "Medical_Details",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Patient_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Details_Patients_Patient_Id",
                table: "Medical_Details");

            migrationBuilder.RenameColumn(
                name: "Patient_Id",
                table: "Medical_Details",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Medical_Details_Patient_Id",
                table: "Medical_Details",
                newName: "IX_Medical_Details_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Details_Patients_PatientId",
                table: "Medical_Details",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Patient_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
