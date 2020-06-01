using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Manager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Employee",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>()
                },
                constraints: table => { table.PrimaryKey("PK_Employee", x => x.Id); });

            migrationBuilder.CreateTable(
                "Business",
                table => new
                {
                    ID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.ID);
                    table.ForeignKey(
                        "FK_Business_Employee_EmployeeId",
                        x => x.EmployeeId,
                        "Employee",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Customer",
                table => new
                {
                    ID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsLargeCompany = table.Column<bool>(),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        "FK_Customer_Employee_EmployeeId",
                        x => x.EmployeeId,
                        "Employee",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Business_EmployeeId",
                "Business",
                "EmployeeId");

            migrationBuilder.CreateIndex(
                "IX_Customer_EmployeeId",
                "Customer",
                "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Business");

            migrationBuilder.DropTable(
                "Customer");

            migrationBuilder.DropTable(
                "Employee");
        }
    }
}