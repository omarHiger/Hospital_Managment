using Microsoft.EntityFrameworkCore.Migrations;

namespace LastHMS.Migrations
{
    public partial class AddDepartmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Department_Id",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ho_Id = table.Column<int>(type: "int", nullable: false),
                    Dept_Mgr_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_Id);
                    table.ForeignKey(
                        name: "FK_Departments_Doctors_Dept_Mgr_Id",
                        column: x => x.Dept_Mgr_Id,
                        principalTable: "Doctors",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.UniqueConstraint("Departments_Dept_Mgr_Id_Unique", x => x.Dept_Mgr_Id);

                    table.ForeignKey(
                        name: "FK_Departments_Hospitals_Ho_Id",
                        column: x => x.Ho_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Ho_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Department_Id",
                table: "Doctors",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Dept_Mgr_Id",
                table: "Departments",
                column: "Dept_Mgr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Ho_Id",
                table: "Departments",
                column: "Ho_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Departments_Department_Id",
                table: "Doctors",
                column: "Department_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Departments_Department_Id",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Department_Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Department_Id",
                table: "Doctors");
        }
    }
}
