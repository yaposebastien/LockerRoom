using Microsoft.EntityFrameworkCore.Migrations;

namespace Locker.Migrations
{
    public partial class InitialLocker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeePhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "LockerCase",
                columns: table => new
                {
                    LockerCaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LockerCaseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerCase", x => x.LockerCaseId);
                });

            migrationBuilder.CreateTable(
                name: "AssignedEmployeeLockerCase",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    LockerCaseId = table.Column<int>(nullable: false),
                    EmployeeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedEmployeeLockerCase", x => new { x.EmployeeId, x.LockerCaseId });
                    table.ForeignKey(
                        name: "FK_AssignedEmployeeLockerCase_Employee_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignedEmployeeLockerCase_LockerCase_LockerCaseId",
                        column: x => x.LockerCaseId,
                        principalTable: "LockerCase",
                        principalColumn: "LockerCaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedEmployeeLockerCase_EmployeeId1",
                table: "AssignedEmployeeLockerCase",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedEmployeeLockerCase_LockerCaseId",
                table: "AssignedEmployeeLockerCase",
                column: "LockerCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedEmployeeLockerCase");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "LockerCase");
        }
    }
}
