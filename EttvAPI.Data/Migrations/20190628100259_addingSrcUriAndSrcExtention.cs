using Microsoft.EntityFrameworkCore.Migrations;

namespace EttvAPI.Data.Migrations
{
    public partial class addingSrcUriAndSrcExtention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "VideoContent",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SrcExtention",
                table: "VideoContent",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SrcUri",
                table: "VideoContent",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrcExtention",
                table: "VideoContent");

            migrationBuilder.DropColumn(
                name: "SrcUri",
                table: "VideoContent");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "VideoContent",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
