using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pobreTITO.Migrations
{
    public partial class FixedReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Reports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_userId",
                table: "Reports",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_userId",
                table: "Reports",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_userId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_userId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Reports",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
