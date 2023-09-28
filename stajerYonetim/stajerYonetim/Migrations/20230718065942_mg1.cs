using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stajerYonetim.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: false),
                    CompanyCompId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_Companies_CompanyCompId",
                        column: x => x.CompanyCompId,
                        principalTable: "Companies",
                        principalColumn: "CompId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    InternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterntSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternUni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternGitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternLengues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternWant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: false),
                    CompanyCompId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_Interns_Companies_CompanyCompId",
                        column: x => x.CompanyCompId,
                        principalTable: "Companies",
                        principalColumn: "CompId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    ReqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqtSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqUni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqGitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqLengues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqWant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompId = table.Column<int>(type: "int", nullable: false),
                    CompanyCompId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.ReqId);
                    table.ForeignKey(
                        name: "FK_Requests_Companies_CompanyCompId",
                        column: x => x.CompanyCompId,
                        principalTable: "Companies",
                        principalColumn: "CompId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CompanyCompId",
                table: "Admins",
                column: "CompanyCompId");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_CompanyCompId",
                table: "Interns",
                column: "CompanyCompId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CompanyCompId",
                table: "Requests",
                column: "CompanyCompId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
