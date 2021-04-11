using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blossom.Data.Model.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bc_businessprofile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Website = table.Column<string>(type: "text", nullable: true),
                    size = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bc_businessprofile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bc_studentprofile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    University = table.Column<string>(type: "text", nullable: true),
                    Degree = table.Column<string>(type: "text", nullable: true),
                    Majors = table.Column<string>(type: "text", nullable: true),
                    Graduating = table.Column<string>(type: "text", nullable: true),
                    WorkingStatus = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bc_studentprofile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bc_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    authId = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StudentProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bc_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_bc_user_bc_businessprofile_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "bc_businessprofile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bc_user_bc_studentprofile_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "bc_studentprofile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bc_user_authId",
                table: "bc_user",
                column: "authId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bc_user_BusinessProfileId",
                table: "bc_user",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_bc_user_StudentProfileId",
                table: "bc_user",
                column: "StudentProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bc_user");

            migrationBuilder.DropTable(
                name: "bc_businessprofile");

            migrationBuilder.DropTable(
                name: "bc_studentprofile");
        }
    }
}
