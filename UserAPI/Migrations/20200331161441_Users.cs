using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    Role = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "StudentProspects",
                columns: table => new
                {
                    ProspectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    FatherName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProspects", x => x.ProspectId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    FatherName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Qualification = table.Column<string>(type: "varchar(30)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false),
                    AssessmentName = table.Column<string>(type: "varchar(30)", nullable: false),
                    AssessmentLink = table.Column<string>(type: "varchar(200)", nullable: false),
                    DeadLine = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentResults",
                columns: table => new
                {
                    StudentResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResults", x => x.StudentResultId);
                    table.ForeignKey(
                        name: "FK_StudentResults_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TeacherId",
                table: "Assessments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResults_AssessmentId",
                table: "StudentResults",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResults_StudentId",
                table: "StudentResults",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StudentProspects");

            migrationBuilder.DropTable(
                name: "StudentResults");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
