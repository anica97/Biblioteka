using Microsoft.EntityFrameworkCore.Migrations;

namespace back.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BibliotekaId",
                table: "knjige",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "knjiga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knjiga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_knjiga_knjige_RedId",
                        column: x => x.RedId,
                        principalTable: "knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_knjige_BibliotekaId",
                table: "knjige",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_knjiga_RedId",
                table: "knjiga",
                column: "RedId");

            migrationBuilder.AddForeignKey(
                name: "FK_knjige_Biblioteke_BibliotekaId",
                table: "knjige",
                column: "BibliotekaId",
                principalTable: "Biblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_knjige_Biblioteke_BibliotekaId",
                table: "knjige");

            migrationBuilder.DropTable(
                name: "Biblioteke");

            migrationBuilder.DropTable(
                name: "knjiga");

            migrationBuilder.DropIndex(
                name: "IX_knjige_BibliotekaId",
                table: "knjige");

            migrationBuilder.DropColumn(
                name: "BibliotekaId",
                table: "knjige");
        }
    }
}
