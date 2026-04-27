using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattlePath.Migrations
{
    /// <inheritdoc />
    public partial class AddSaveDataToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaveDataJson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveDataJson",
                table: "AspNetUsers");
        }
    }
}
