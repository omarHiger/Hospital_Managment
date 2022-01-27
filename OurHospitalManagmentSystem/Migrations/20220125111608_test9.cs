using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurHospitalManagmentSystem.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Serial_Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111111, 1"),
                    Ho_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ho_Subscribtion_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hospital_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hospital_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hospital_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mgr_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Serial_Number);
                    table.ForeignKey(
                        name: "FK_Hospitals_Doctors_Mgr_Id",
                        column: x => x.Mgr_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospital_Phone_Numbers",
                columns: table => new
                {
                    Serial_Number = table.Column<int>(type: "int", nullable: false),
                    Hospital_Phone_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital_Phone_Numbers", x => new { x.Serial_Number, x.Hospital_Phone_Number });
                    table.ForeignKey(
                        name: "FK_Hospital_Phone_Numbers_Hospitals_Serial_Number",
                        column: x => x.Serial_Number,
                        principalTable: "Hospitals",
                        principalColumn: "Serial_Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Serial_Number",
                table: "Patients",
                column: "Serial_Number");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Mgr_Id",
                table: "Hospitals",
                column: "Mgr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_Serial_Number",
                table: "Patients",
                column: "Serial_Number",
                principalTable: "Hospitals",
                principalColumn: "Serial_Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_Serial_Number",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Hospital_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Serial_Number",
                table: "Patients");
        }
    }
}
