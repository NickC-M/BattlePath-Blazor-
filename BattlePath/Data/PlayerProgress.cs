namespace BattlePath.Data
{
    public class PlayerProgress
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int Health { get; set; } = 100;
    }
}
