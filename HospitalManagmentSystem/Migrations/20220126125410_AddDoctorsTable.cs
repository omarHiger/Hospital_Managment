using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddDoctorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mgr_Id",
                table: "Hospitals",
                type: "int",
                nullable: true);

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
                    Doctor_Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
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
                    Doctor_Phone_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Mgr_Id",
                table: "Hospitals",
                column: "Mgr_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Doctors_Mgr_Id",
                table: "Hospitals",
                column: "Mgr_Id",
                principalTable: "Doctors",
                principalColumn: "Doctor_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Doctors_Mgr_Id",
                table: "Hospitals");

            migrationBuilder.DropTable(
                name: "Doctor_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_Mgr_Id",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Mgr_Id",
                table: "Hospitals");
        }
    }
}
