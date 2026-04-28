using BattlePath.Models;
using Microsoft.CodeAnalysis.Differencing;
using static System.Net.Mime.MediaTypeNames;

namespace BattlePath.Services
{
    public class GameStateService
    {
        public int PlayerHealth { get; set; } = 50;
        public int PlayerMaxHealth { get; set; } = 50;
        public int PlayerAttack { get; set; } = 10;
        public int PlayerExp { get; set; } = 0;
        public int PlayerLvl { get; set; } = 1;

        public int PlayerPerma { get; set; } = 0;

        public int GridWidth { get; set; } = 12;
        public int GridHeight { get; set; } = 12;

        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public Enemy? CurrentEnemy { get; set; }
        public int CurrentEnemyMaxHp { get; set; }

        public List<Enemy> Enemies { get; set; } = new();

        public List<Position> Waters { get; set; } = new();
        public Position Exit { get; set; }

        private Random rng = new Random();

        private int numEnemies = 9;

        public bool InCombat { get; set; } = false;

        public int depth { get; set; } = 0;


        //create a new room
        public void GenerateRoom()
        {
            if(PlayerHealth != PlayerMaxHealth)
            {
                PlayerHealth = Math.Min((PlayerHealth + PlayerMaxHealth / 5), PlayerMaxHealth);
            }
            depth++;
            PlayerX = 0;
            PlayerY = 0;
            Enemies.Clear();
            Waters.Clear();
            int i = 0;
           // numEnemies += Math.Min((depth), 15);
            //place enemies randomly
            while (Enemies.Count < numEnemies)
            {
                
                int ex = rng.Next(GridWidth);
                int ey = rng.Next(GridHeight);

                if ((ex != PlayerX || ey != PlayerY) &&
                    !Enemies.Any(e => e.X == ex && e.Y == ey))
                {
                    int n = rng.Next(3);
                    if(depth < 3) Enemies.Add(new Enemy(i,ex, ey, "Goblin", 30, 5, "images/goblin.png",4));

                    else if (n == 0)
                    {
                        Enemies.Add(new Enemy(i, ex, ey, "Goblin", 30+(depth/3), 5, "images/goblin.png", (4 + (depth / 4))));                         //scaling tied to depth
                    }
                    else if (n == 1)
                    {
                        Enemies.Add(new Enemy(i,ex, ey, "Skeleton", 25 + (depth / 2), 8, "images/skeloton.png", (7 + (depth / 3))));
                    }
                    else if (n == 2)
                    {
                        Enemies.Add(new Enemy(i,ex, ey, "Rat", 15 + (depth), 16 + (depth / 3), "images/rat.png", (15 + (depth / 2))));
                    }
                }
                i++;
            }
            //place water randomly
            while (Waters.Count < 20)
            {
                int wx = rng.Next(GridWidth);
                int wy = rng.Next(GridHeight);

                while(wx < 4 && wy < 4)
                {
                    wx = rng.Next(GridWidth);
                    wy = rng.Next(GridHeight);
                }
                if ((wx != PlayerX || wy != PlayerY) &&
                    !Waters.Any(w => w.X == wx && w.Y == wy) && !Enemies.Any(e => e.X == wx && e.Y == wy))
                {
                    Waters.Add(new Position { X = wx, Y = wy });
                }
            }

            //create exit

            int exitX = rng.Next(GridWidth);
            int exitY = rng.Next(GridHeight);
            while (exitX < 4 && exitY < 4)
            {
                exitX = rng.Next(GridWidth);
                exitY = rng.Next(GridHeight);
            }
            while ((Enemies.Any(e => e.X == exitX && e.Y == exitY)) || (exitX == PlayerX && exitY == PlayerY) || Waters.Any(e => e.X == exitX && e.Y == exitY))
            {
                exitX = rng.Next(GridWidth);
                exitY = rng.Next(GridHeight);
            }


            Exit = new Position { X = exitX, Y = exitY };
        }

        public bool MovePlayer(int dx, int dy)
        {
            
 
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
            


            Position test = new Position();

            foreach(Position e in Enemies)
            {

                int space = Math.Abs(e.X - PlayerX) + Math.Abs(e.Y - PlayerY);

                if (space < 4)
                {
                    int dx = PlayerX - e.X;
                    int dy = PlayerY - e.Y;

                    if (Math.Abs(dx) > Math.Abs(dy))
                    {
                        test.X = e.X + Math.Sign(dx);
                        test.Y = e.Y;
                    }
                    else
                    {
                        test.X = e.X;
                        test.Y = e.Y + Math.Sign(dy);
                    }

                    if (IsBlocked(test))  continue;

                    e.X = test.X;
                    e.Y = test.Y;
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
            CurrentEnemy = Enemies.FirstOrDefault(e => e.X == PlayerX && e.Y == PlayerY);
            CurrentEnemyMaxHp = CurrentEnemy.Hp;
            InCombat = true;
        }


        public void EndCombat()
        {
            
            
            InCombat = false;
        }

        public void PlayerDeath()
        {
            for(int i = 0; i < PlayerLvl / 10; i++)
            {
                PlayerLvl -= 10;
                PlayerPerma++;
            }
           
            depth = 0;
            PlayerExp = 0;
            PlayerLvl = 0;
            PlayerMaxHealth = 50 + (4 * PlayerPerma);
            PlayerHealth = PlayerMaxHealth;
            PlayerAttack = 10 + PlayerPerma;
            GenerateRoom();
        }

    }
}