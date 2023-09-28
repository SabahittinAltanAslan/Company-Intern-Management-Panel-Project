using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stajerYonetim.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Interns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PdfRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternPdfRecord",
                columns: table => new
                {
                    InternsInternId = table.Column<int>(type: "int", nullable: false),
                    PdfRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternPdfRecord", x => new { x.InternsInternId, x.PdfRecordsId });
                    table.ForeignKey(
                        name: "FK_InternPdfRecord_Interns_InternsInternId",
                        column: x => x.InternsInternId,
                        principalTable: "Interns",
                        principalColumn: "InternId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternPdfRecord_PdfRecords_PdfRecordsId",
                        column: x => x.PdfRecordsId,
                        principalTable: "PdfRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternPdfRecord_PdfRecordsId",
                table: "InternPdfRecord",
                column: "PdfRecordsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternPdfRecord");

            migrationBuilder.DropTable(
                name: "PdfRecords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Interns");
        }
    }
}
