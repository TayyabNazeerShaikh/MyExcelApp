using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyExcelApp.MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcelFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsHeaderPresent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeaderStyle = table.Column<string>(type: "TEXT", nullable: false),
                    RowStyle = table.Column<string>(type: "TEXT", nullable: true),
                    ColumnStyle = table.Column<string>(type: "TEXT", nullable: true),
                    CellStyle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelFiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelFiles");
        }
    }
}
