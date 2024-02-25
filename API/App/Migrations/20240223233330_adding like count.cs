using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.API.Migrations
{
    /// <inheritdoc />
    public partial class addinglikecount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Posts");
        }
    }
}
