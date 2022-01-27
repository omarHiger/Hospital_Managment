using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddHospitalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Hospital_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Ho_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital_Phone_Numbers",
                columns: table => new
                {
                    Ho_Id = table.Column<int>(type: "int", nullable: false),
                    Hospital_Phone_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospital_Phone_Numbers");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
