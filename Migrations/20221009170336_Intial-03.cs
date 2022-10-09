using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class Intial03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Empoyee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empoyee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Empoyee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { 1, "Test01" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { 2, "Test02" });

            migrationBuilder.InsertData(
                table: "Empoyee",
                columns: new[] { "EmployeeId", "DepartmentId", "Hours", "Name", "PayRate", "StartDate", "Title" },
                values: new object[] { 1, 1, 12.5m, "dsdsdd", 12.5m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "111" });

            migrationBuilder.CreateIndex(
                name: "IX_Empoyee_DepartmentId",
                table: "Empoyee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empoyee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}