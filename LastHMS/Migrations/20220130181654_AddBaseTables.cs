﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LastHMS.Migrations
{
    public partial class AddBaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111111, 1"),
                    Doctor_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Doctor_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Doctor_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Doctor_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Doctor_Family_Members = table.Column<int>(type: "int", nullable: false),
                    Doctor_Specialization = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Doctor_Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Doctor_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doctor_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Doctor_Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Doctor_Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_Phone_Numbers",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false),
                    Doctor_Phone_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Phone_Numbers", x => new { x.Doctor_Id, x.Doctor_Phone_Number });
                    table.ForeignKey(
                        name: "FK_Doctor_Phone_Numbers_Doctors_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Ho_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111111, 1"),
                    Serial_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ho_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ho_Subscribtion_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hospital_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hospital_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hospital_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mgr_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Ho_Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Doctors_Mgr_Id",
                        column: x => x.Mgr_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.UniqueConstraint("Hospitals_Doctors_Mgr_Id_Unique", x => x.Mgr_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111111, 1"),
                    Employee_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Employee_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Employee_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Employee_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Employee_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Employee_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Employee_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Employee_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_X_Y = table.Column<string>(type: "nvarchar(61)", maxLength: 61, nullable: false),
                    Employee_Family_Members = table.Column<int>(type: "int", nullable: false),
                    Employee_Job = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Employee_Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Social_Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Employee_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Employee_Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ho_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Hospitals_Ho_Id",
                        column: x => x.Ho_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Ho_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospital_Phone_Numbers",
                columns: table => new
                {
                    Ho_Id = table.Column<int>(type: "int", nullable: false),
                    Hospital_Phone_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital_Phone_Numbers", x => new { x.Ho_Id, x.Hospital_Phone_Number });
                    table.ForeignKey(
                        name: "FK_Hospital_Phone_Numbers_Hospitals_Ho_Id",
                        column: x => x.Ho_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Ho_Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Patient_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Patient_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Patient_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Patient_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ho_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_Ho_Id",
                        column: x => x.Ho_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Ho_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Phone_Numbers",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Phone_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Phone_Numbers", x => new { x.Employee_Id, x.Employee_Phone_Number });
                    table.ForeignKey(
                        name: "FK_Employee_Phone_Numbers_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Patient_Phone_Numbers",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    Patient_Phone_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Caring_Patient_Id",
                table: "Caring",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Ho_Id",
                table: "Employees",
                column: "Ho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Mgr_Id",
                table: "Hospitals",
                column: "Mgr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Ho_Id",
                table: "Patients",
                column: "Ho_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caring");

            migrationBuilder.DropTable(
                name: "Doctor_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Employee_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Hospital_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Patient_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
