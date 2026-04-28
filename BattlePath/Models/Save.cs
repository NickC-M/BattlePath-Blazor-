namespace BattlePath.Models
{
    public class Save
    {

        public int PlayerHealth { get; set; }
        public int PlayerMaxHealth { get; set; } = 0;

        public int PlayerExp { get; set; }
        public int PlayerLvl { get; set; }
        public int PlayerPerma { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public int PlayerAttack { get; set; }

        public List<Enemy> Enemies { get; set; } = new();
        public Enemy? CurrentEnemy { get; set; }
        public Position Exit { get; set; }
        public List<Position> Waters { get; set; } = new();
        public bool InCombat { get; set; } = false;
        public int depth { get; set; }



    }
}
