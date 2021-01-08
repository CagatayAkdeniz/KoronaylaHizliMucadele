using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaHastaTakip.DataAccess.Migrations
{
    public partial class TabloSonHali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bildirim_AspNetUsers_AppUserId",
                table: "Bildirim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bildirim",
                table: "Bildirim");

            migrationBuilder.RenameTable(
                name: "Bildirim",
                newName: "Bildirimler");

            migrationBuilder.RenameIndex(
                name: "IX_Bildirim_AppUserId",
                table: "Bildirimler",
                newName: "IX_Bildirimler_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bildirimler",
                table: "Bildirimler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bildirimler_AspNetUsers_AppUserId",
                table: "Bildirimler",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bildirimler_AspNetUsers_AppUserId",
                table: "Bildirimler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bildirimler",
                table: "Bildirimler");

            migrationBuilder.RenameTable(
                name: "Bildirimler",
                newName: "Bildirim");

            migrationBuilder.RenameIndex(
                name: "IX_Bildirimler_AppUserId",
                table: "Bildirim",
                newName: "IX_Bildirim_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bildirim",
                table: "Bildirim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bildirim_AspNetUsers_AppUserId",
                table: "Bildirim",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
