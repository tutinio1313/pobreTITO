using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pobreTITO.Migrations
{
    public partial class updateMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_userId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reports",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Reports",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "imageURL",
                table: "Reports",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Reports",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Reports",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reports",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_userId",
                table: "Reports",
                newName: "IX_Reports_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_UserId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reports",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Reports",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Reports",
                newName: "imageURL");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reports",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Reports",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reports",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                newName: "IX_Reports_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_userId",
                table: "Reports",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
