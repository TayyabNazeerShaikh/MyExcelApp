using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyExcelApp.MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFileNameToExcelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ExcelData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ExcelData");
        }
    }
}
