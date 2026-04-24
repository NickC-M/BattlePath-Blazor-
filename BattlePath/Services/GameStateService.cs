using BattlePath.Models;
using Microsoft.CodeAnalysis.Differencing;
using static System.Net.Mime.MediaTypeNames;

namespace BattlePath.Services
{
    public class GameStateService
    {
        public int PlayerHealth { get; set; } = 100;
        public int PlayerAttack { get; set; } = 10;
        public int EnemyHealth { get; set; } = 50;

        public int GridWidth { get; set; } = 14;
        public int GridHeight { get; set; } = 12;

        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public List<Position> Enemies { get; set; } = new();

        public List<Position> Waters { get; set; } = new();
        public Position Exit { get; set; }

        private Random rng = new Random();

        private int numEnemies = 6;

        public bool InCombat { get; set; } = false;

        public int depth { get; set; } = 0;


        //create a new room
        public void GenerateRoom()
        {
            depth++;
            PlayerX = 0;
            PlayerY = 0;
            Enemies.Clear();
            Waters.Clear();
            numEnemies += Math.Min((depth), 15);
            //place enemies randomly
            while (Enemies.Count < numEnemies)
            {
                int ex = rng.Next(GridWidth);
                int ey = rng.Next(GridHeight);

                if ((ex != PlayerX || ey != PlayerY) &&
                    !Enemies.Any(e => e.X == ex && e.Y == ey))
                {
                    Enemies.Add(new Position { X = ex, Y = ey });
                }
            }
            //place water randomly
            while (Waters.Count < 14)
            {
                int wx = rng.Next(GridWidth);
                int wy = rng.Next(GridHeight);

                if ((wx != PlayerX || wy != PlayerY) &&
                    !Waters.Any(w => w.X == wx && w.Y == wy) && !Enemies.Any(e => e.X == wx && e.Y == wy))
                {
                    Waters.Add(new Position { X = wx, Y = wy });
                }
            }

            //create exit

            int exitX = rng.Next(GridWidth);
            int exitY = rng.Next(GridHeight);
            while ((Enemies.Any(e => e.X == exitX && e.Y == exitY)) || (exitX == PlayerX && exitY == PlayerY))
            {
                exitX = rng.Next(GridWidth);
                exitY = rng.Next(GridHeight);
            }

            Exit = new Position { X = exitX, Y = exitY };
        }

        public bool MovePlayer(int dx, int dy)
        {
            MoveEnemies();
 
            int nx = PlayerX + dx;
            int ny = PlayerY + dy;

            if (nx < 0 || nx >= GridWidth || ny < 0 || ny >= GridHeight)
                return false;

            PlayerX = nx;
            PlayerY = ny;
            
            return true;
        }

        public void MoveEnemies()
        {
            //move enemies 1 square if within 4 spaces to player 
            //place this function in moveplayer so that enemies move every time player moves


            Position test = new Position();

            foreach(Position e in Enemies)
            {

                int space = Math.Abs(e.X - PlayerX) + Math.Abs(e.Y - PlayerY);

                if (space < 5)
                {
                    if (e.Y < PlayerY)
                    {
                        test.X = e.X; test.Y = e.Y+ 1;
                        if (IsBlocked(test)) continue;
                        e.Y++;
                    }
                    else if (e.Y == PlayerY) 
                    {
                        if(e.X < PlayerX)
                        {
                            test.X = e.X + 1; test.Y = e.Y;
                            if (IsBlocked(test)) continue;
                            e.X++;
                        }else
                        {
                            test.X = e.X - 1; test.Y = e.Y;
                            if (IsBlocked(test)) continue;
                            e.X--;
                        }
                    }
                    else
                    {
                        test.X = e.X; test.Y = e.Y - 1;
                        if (IsBlocked(test)) continue;
                        e.Y--;
                    }
                }

            }

        }

        public bool IsEnemyHere() => Enemies.Any(e => e.X == PlayerX && e.Y == PlayerY);
        public bool IsEnemyHere(Position en) => Enemies.Any(e => e.X == en.X && e.Y == en.Y);
        public bool IsExitHere() => PlayerX == Exit.X && PlayerY == Exit.Y;
        public bool IsExitHere(Position e) => e.X == Exit.X && e.Y == Exit.Y;
        public bool IsPlayerHere(Position e) => e.X == PlayerX && e.Y == PlayerY;
        public bool IsWaterHere() => Waters.Any(w => w.X == PlayerX && w.Y == PlayerY);
        public bool IsWaterHere(Position wa) => Waters.Any(w => w.X == wa.X && w.Y == wa.Y);

        private bool IsBlocked(Position p)
        {
            return (IsEnemyHere(p) || IsExitHere(p) || IsPlayerHere(p) || IsWaterHere(p));
        }
        public void StartCombat()
        {
            EnemyHealth = 50;
            InCombat = true;
        }


        public void EndCombat()
        {
            InCombat = false;
        }

    }
}