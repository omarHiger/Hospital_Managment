using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddRaysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rays",
                columns: table => new
                {
                    Ray_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ray_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ray_Type = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ray_Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rays", x => x.Ray_Id);
                    table.ForeignKey(
                        name: "FK_Rays_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rays_Patient_Id",
                table: "Rays",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rays");
        }
    }
}
