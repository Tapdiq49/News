using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPhotos_News_NewsId",
                table: "NewsPhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPhotos_News_NewsId",
                table: "NewsPhotos",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPhotos_News_NewsId",
                table: "NewsPhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPhotos_News_NewsId",
                table: "NewsPhotos",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
