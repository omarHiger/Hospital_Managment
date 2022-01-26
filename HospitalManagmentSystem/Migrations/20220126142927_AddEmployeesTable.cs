using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddEmployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Patient_National_Number",
                table: "Patients",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

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
                name: "Employee_Phone_Numbers",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Phone_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Ho_Id",
                table: "Employees",
                column: "Ho_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Patient_National_Number",
                table: "Patients",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
