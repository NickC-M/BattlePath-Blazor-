namespace BattlePath.Models
{
    public class Save
    {

        public int PlayerHealth { get; set; } = 50;
        public int PlayerMaxHealth { get; set; } = 50;
        public int PlayerExp { get; set; }
        public int PlayerLvl { get; set; }

        public int PlayerAttack { get; set; } = 10;

        public List<Enemy> Enemies { get; set; } = new();
        public Enemy? CurrentEnemy { get; set; }
        public Position Exit { get; set; }
        public List<Position> Waters { get; set; } = new();
        public bool InCombat { get; set; } = false;
        public int depth { get; set; } = 0;



    }
}
