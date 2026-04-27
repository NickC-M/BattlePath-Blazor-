using BattlePath.Models;
namespace BattlePath.Services
{
    public class SaveService
    {

        public Save CreateSave(GameStateService game)
        {
            return new Save
            {
                PlayerHealth = game.PlayerHealth,
                PlayerMaxHealth = game.PlayerMaxHealth,
                PlayerExp = game.PlayerExp,
                PlayerLvl = game.PlayerLvl,
                PlayerAttack = game.PlayerAttack,

                PlayerX = game.PlayerX,
                PlayerY = game.PlayerY,

                depth = game.depth,
                InCombat = game.InCombat,

                Exit = game.Exit,
                Waters = game.Waters.ToList(),

                Enemies = game.Enemies.Select(e => new Enemy(
                e.Id, e.X, e.Y, e.Name, e.Hp, e.Atk, e.IconPath, e.Xp
                )).ToList(),

                CurrentEnemy = game.CurrentEnemy == null ? null : new Enemy(
                    game.CurrentEnemy.Id,
                    game.CurrentEnemy.X,
                    game.CurrentEnemy.Y,
                    game.CurrentEnemy.Name,
                    game.CurrentEnemy.Hp,
                    game.CurrentEnemy.Atk,
                    game.CurrentEnemy.IconPath,
                    game.CurrentEnemy.Xp
                )
            };
        }

        public void LoadSave(Save save, GameStateService game)
        {
            game.PlayerHealth = save.PlayerHealth;
            game.PlayerMaxHealth = save.PlayerMaxHealth;
            game.PlayerExp = save.PlayerExp;
            game.PlayerLvl = save.PlayerLvl;
            game.PlayerAttack = save.PlayerAttack;
            game.PlayerX = save.PlayerX;
            game.PlayerY = save.PlayerY;

            game.depth = save.depth;
            game.InCombat = save.InCombat;

            game.Exit = save.Exit;
            game.Waters = save.Waters.ToList();

            //rebuild enemies
            game.Enemies = save.Enemies.Select(e => new Enemy(
                e.Id, e.X, e.Y, e.Name, e.Hp, e.Atk, e.IconPath, e.Xp
            )).ToList();

            game.CurrentEnemy = save.CurrentEnemy == null ? null : new Enemy(
                save.CurrentEnemy.Id,
                save.CurrentEnemy.X,
                save.CurrentEnemy.Y,
                save.CurrentEnemy.Name,
                save.CurrentEnemy.Hp,
                save.CurrentEnemy.Atk,
                save.CurrentEnemy.IconPath,
                save.CurrentEnemy.Xp
            );
        }




    }
}


 
