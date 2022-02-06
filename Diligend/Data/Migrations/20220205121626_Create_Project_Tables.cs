using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diligend.Data.Migrations
{
    public partial class Create_Project_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FirstNameComments = table.Column<string>(nullable: true),
                    FirstNameScore = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastNameComments = table.Column<string>(nullable: true),
                    LastNameScore = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    AgeComments = table.Column<string>(nullable: true),
                    AgeScore = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    SchoolNameComments = table.Column<string>(nullable: true),
                    SchoolNameScore = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollegeForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CollegeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeForms_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollegeForms_CollegeId",
                table: "CollegeForms",
                column: "CollegeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeForms");

            migrationBuilder.DropTable(
                name: "RegistrationForms");

            migrationBuilder.DropTable(
                name: "Colleges");
        }
    }
}
