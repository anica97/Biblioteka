using Microsoft.EntityFrameworkCore.Migrations;

namespace back.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "red",
                newName: "Zanr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zanr",
                table: "red",
                newName: "Naziv");
        }
    }
}
