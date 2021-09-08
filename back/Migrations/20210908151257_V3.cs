using Microsoft.EntityFrameworkCore.Migrations;

namespace back.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_knjiga_knjige_RedId",
                table: "knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_knjige_Biblioteke_BibliotekaId",
                table: "knjige");

            migrationBuilder.DropPrimaryKey(
                name: "PK_knjige",
                table: "knjige");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biblioteke",
                table: "Biblioteke");

            migrationBuilder.RenameTable(
                name: "knjige",
                newName: "red");

            migrationBuilder.RenameTable(
                name: "Biblioteke",
                newName: "biblioteka");

            migrationBuilder.RenameIndex(
                name: "IX_knjige_BibliotekaId",
                table: "red",
                newName: "IX_red_BibliotekaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_red",
                table: "red",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_biblioteka",
                table: "biblioteka",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_knjiga_red_RedId",
                table: "knjiga",
                column: "RedId",
                principalTable: "red",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_red_biblioteka_BibliotekaId",
                table: "red",
                column: "BibliotekaId",
                principalTable: "biblioteka",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_knjiga_red_RedId",
                table: "knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_red_biblioteka_BibliotekaId",
                table: "red");

            migrationBuilder.DropPrimaryKey(
                name: "PK_red",
                table: "red");

            migrationBuilder.DropPrimaryKey(
                name: "PK_biblioteka",
                table: "biblioteka");

            migrationBuilder.RenameTable(
                name: "red",
                newName: "knjige");

            migrationBuilder.RenameTable(
                name: "biblioteka",
                newName: "Biblioteke");

            migrationBuilder.RenameIndex(
                name: "IX_red_BibliotekaId",
                table: "knjige",
                newName: "IX_knjige_BibliotekaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_knjige",
                table: "knjige",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biblioteke",
                table: "Biblioteke",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_knjiga_knjige_RedId",
                table: "knjiga",
                column: "RedId",
                principalTable: "knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_knjige_Biblioteke_BibliotekaId",
                table: "knjige",
                column: "BibliotekaId",
                principalTable: "Biblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
