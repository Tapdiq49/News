using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdatePropertyOrderBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NewsPhotos_OrderBy_NewsId",
                table: "NewsPhotos",
                columns: new[] { "OrderBy", "NewsId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsPhotos_OrderBy_NewsId",
                table: "NewsPhotos");
        }
    }
}
