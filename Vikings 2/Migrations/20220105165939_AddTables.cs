using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vikings_2.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "11, 1"),
                    Patient_First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Middle_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Patient_Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patient_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Patient_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Patient_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Patient_National_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Patient_Social_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Patient_Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Phone_Numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    Patient_Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Phone_Numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Phone_Numbers_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Previews",
                columns: table => new
                {
                    Preview_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preview_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previews", x => x.Preview_Id);
                    table.ForeignKey(
                        name: "FK_Previews_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Phone_Numbers_Patient_Id",
                table: "Patient_Phone_Numbers",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Previews_Patient_Id",
                table: "Previews",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Previews");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
