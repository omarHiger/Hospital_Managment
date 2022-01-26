using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddCaringBreakTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caring",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caring", x => new { x.Doctor_Id, x.Patient_Id });
                    table.ForeignKey(
                        name: "FK_Caring_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caring_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caring_Patient_Id",
                table: "Caring",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caring");
        }
    }
}
