using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddSurgeriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    Surgery_Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surgery_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surgery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Surgery_Time = table.Column<int>(type: "int", nullable: false),
                    Surgery_Room_Id = table.Column<int>(type: "int", nullable: false),
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.Surgery_Number);
                    table.ForeignKey(
                        name: "FK_Surgeries_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surgeries_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surgeries_Surgery_Rooms_Surgery_Room_Id",
                        column: x => x.Surgery_Room_Id,
                        principalTable: "Surgery_Rooms",
                        principalColumn: "Surgery_Room_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_Doctor_Id",
                table: "Surgeries",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_Patient_Id",
                table: "Surgeries",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_Surgery_Room_Id",
                table: "Surgeries",
                column: "Surgery_Room_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surgeries");
        }
    }
}
