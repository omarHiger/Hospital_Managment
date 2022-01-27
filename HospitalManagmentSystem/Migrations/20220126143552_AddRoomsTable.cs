using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagmentSystem.Migrations
{
    public partial class AddRoomsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Empty = table.Column<bool>(type: "bit", nullable: false),
                    Room_Type = table.Column<int>(type: "int", nullable: false),
                    Ho_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hospitals_Ho_Id",
                        column: x => x.Ho_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Ho_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Ho_Id",
                table: "Patients",
                column: "Ho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Ho_Id",
                table: "Rooms",
                column: "Ho_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_Ho_Id",
                table: "Patients",
                column: "Ho_Id",
                principalTable: "Hospitals",
                principalColumn: "Ho_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_Ho_Id",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Ho_Id",
                table: "Patients");
        }
    }
}
