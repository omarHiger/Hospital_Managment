using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurHospitalManagmentSystem.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Serial_Number",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_National_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Doctor_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Doctor_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doctor_Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Doctor_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Doctor_Family_Members = table.Column<int>(type: "int", nullable: false),
                    Doctor_Specialization = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Doctor_Career = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Doctor_Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Doctor_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doctor_Birth_Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Doctor_Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Doctor_Id);
                    table.UniqueConstraint("Unique_Doctors_National_Number", x=>x.Doctor_National_Number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropColumn(
                name: "Serial_Number",
                table: "Patients");
        }
    }
}
