namespace BattlePath.Models
{
    public class Enemy : Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Hp { get; set; }
        public int Atk { get; set; }

        public string IconPath { get; set; } = string.Empty;

        public Enemy(int id, int x, int y,string name, int hp, int atk, string iconPath)
        {
            Id = id;
            X = x; 
            Y = y;
            Name = name;
            Hp = hp;
            Atk = atk;
            IconPath = iconPath;
        }
    }
}
