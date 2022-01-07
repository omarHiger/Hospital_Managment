using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViKings_1.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
