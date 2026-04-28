using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattlePath.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDefaultSave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SaveDataJson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "{\"PlayerHealth\":50,\"PlayerMaxHealth\":50,\"PlayerExp\":0,\"PlayerLvl\":0,\"PlayerX\":0,\"PlayerY\":0,\"PlayerAttack\":10,\"Enemies\":[{\"Id\":0,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":10,\"Y\":6},{\"Id\":1,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":3,\"Y\":4},{\"Id\":2,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":4,\"Y\":2},{\"Id\":3,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":8,\"Y\":9},{\"Id\":4,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":7,\"Y\":5},{\"Id\":5,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":4,\"Y\":6},{\"Id\":6,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":5,\"Y\":1},{\"Id\":7,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":9,\"Y\":1},{\"Id\":8,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":1,\"Y\":7}],\"CurrentEnemy\":null,\"Exit\":{\"X\":11,\"Y\":11},\"Waters\":[{\"X\":11,\"Y\":10},{\"X\":9,\"Y\":3},{\"X\":4,\"Y\":1},{\"X\":11,\"Y\":5},{\"X\":7,\"Y\":4},{\"X\":8,\"Y\":7},{\"X\":4,\"Y\":5},{\"X\":9,\"Y\":10},{\"X\":11,\"Y\":3},{\"X\":10,\"Y\":4},{\"X\":6,\"Y\":10},{\"X\":8,\"Y\":11},{\"X\":7,\"Y\":10},{\"X\":11,\"Y\":4},{\"X\":8,\"Y\":0},{\"X\":0,\"Y\":7},{\"X\":0,\"Y\":9},{\"X\":3,\"Y\":8},{\"X\":3,\"Y\":5},{\"X\":0,\"Y\":10}],\"InCombat\":false,\"depth\":1}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SaveDataJson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "{\"PlayerHealth\":50,\"PlayerMaxHealth\":50,\"PlayerExp\":0,\"PlayerLvl\":0,\"PlayerX\":0,\"PlayerY\":0,\"PlayerAttack\":10,\"Enemies\":[{\"Id\":0,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":10,\"Y\":6},{\"Id\":1,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":3,\"Y\":4},{\"Id\":2,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":4,\"Y\":2},{\"Id\":3,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":8,\"Y\":9},{\"Id\":4,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":7,\"Y\":5},{\"Id\":5,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":4,\"Y\":6},{\"Id\":6,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":5,\"Y\":1},{\"Id\":7,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":9,\"Y\":1},{\"Id\":8,\"Name\":\"Goblin\",\"Hp\":30,\"Atk\":5,\"Xp\":4,\"IconPath\":\"images/goblin.png\",\"X\":1,\"Y\":7}],\"CurrentEnemy\":null,\"Exit\":{\"X\":11,\"Y\":11},\"Waters\":[{\"X\":11,\"Y\":10},{\"X\":9,\"Y\":3},{\"X\":4,\"Y\":1},{\"X\":11,\"Y\":5},{\"X\":7,\"Y\":4},{\"X\":8,\"Y\":7},{\"X\":4,\"Y\":5},{\"X\":9,\"Y\":10},{\"X\":11,\"Y\":3},{\"X\":10,\"Y\":4},{\"X\":6,\"Y\":10},{\"X\":8,\"Y\":11},{\"X\":7,\"Y\":10},{\"X\":11,\"Y\":4},{\"X\":8,\"Y\":0},{\"X\":0,\"Y\":7},{\"X\":0,\"Y\":9},{\"X\":3,\"Y\":8},{\"X\":3,\"Y\":5},{\"X\":0,\"Y\":10}],\"InCombat\":false,\"depth\":1}",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
