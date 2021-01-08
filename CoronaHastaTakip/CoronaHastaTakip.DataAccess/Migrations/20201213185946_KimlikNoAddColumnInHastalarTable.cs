using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaHastaTakip.DataAccess.Migrations
{
    public partial class KimlikNoAddColumnInHastalarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Hastalar");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Hastalar",
                newName: "AdSoyad");

            migrationBuilder.AddColumn<string>(
                name: "KimlikNo",
                table: "Hastalar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_KimlikNo",
                table: "Hastalar",
                column: "KimlikNo",
                unique: true,
                filter: "[KimlikNo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hastalar_KimlikNo",
                table: "Hastalar");

            migrationBuilder.DropColumn(
                name: "KimlikNo",
                table: "Hastalar");

            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Hastalar",
                newName: "Ad");

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Hastalar",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
