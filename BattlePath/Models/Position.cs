namespace BattlePath.Models
{
    public class Position
    {
        //this class exists because javascript does not play nice with tuples like int x, int y
        public int X { get; set; }
        public int Y { get; set; }
    }
}
