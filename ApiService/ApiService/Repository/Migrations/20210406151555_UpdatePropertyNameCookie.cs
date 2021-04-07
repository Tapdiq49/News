using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdatePropertyNameCookie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cookie",
                table: "LikesDislikes");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "LikesDislikes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "LikesDislikes");

            migrationBuilder.AddColumn<string>(
                name: "Cookie",
                table: "LikesDislikes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
