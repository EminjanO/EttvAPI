using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EttvAPI.Data.Migrations
{
    public partial class VideosChannelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoContent",
                columns: table => new
                {
                    VideoId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoContent", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_VideoContent_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ChannelProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    AppUserId = table.Column<int>(nullable: false),
                    VideoContentVideoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelProgram_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelProgram_VideoContent_VideoContentVideoId",
                        column: x => x.VideoContentVideoId,
                        principalTable: "VideoContent",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelProgram_AppUserId",
                table: "ChannelProgram",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelProgram_VideoContentVideoId",
                table: "ChannelProgram",
                column: "VideoContentVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoContent_AppUserId",
                table: "VideoContent",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelProgram");

            migrationBuilder.DropTable(
                name: "VideoContent");
        }
    }
}
