using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace KleinGarterRevision
{
    public class Game
    {
        Config.ConfigData config = Config.GetConfigData();

        #region Values
        private ConsoleKey Direction = ConsoleKey.DownArrow;
        private int BackgroundColor => config.BackgroundColor;
        private int BorderColor => config.BorderColor;
        private int BodyColor;
        private int HeadColor;
        private int FoodColor;

        private GameObject SnakeHead;
        private Queue<GameObject> Snake = new Queue<GameObject>();
        private GameObject Food;
        private bool Alive = true;
        private int Score;
        private int FoodConsumed;
        private double Speed;
        private double SpeedIncrease;
        private double SpeedCount;


        //private int PlayerColorScheme => config.PlayerColorScheme;
        private char PlayerSkin => config.PlayerSkin;
        private int MinSpeed => config.MinSpeed;
        private int MaxSpeed => config.MaxSpeed;
        private char Border => config.Border;
        private bool FunkyMode => config.FunkyMode;

        //private int LevelColorScheme => config.LevelColorScheme;
        private int LevelWidth => config.LevelWidth;
        private int LevelHeight => config.LevelHeight;
        private int LevelDifficulty => config.LevelDifficulty;
        #endregion

        public void RunGame()
        {
            #region Start configuration
            BodyColor = config.BodyColor;
            HeadColor = config.HeadColor;
            FoodColor = config.FoodColor;

            Food = new GameObject(0, 0);
            FoodConsumed = config.FoodConsumed;
            Speed = MinSpeed;
            SpeedIncrease = (MaxSpeed - Speed) / ((LevelWidth - 2) * (LevelHeight - 2)) * LevelDifficulty; //Finds appropriate speed increase compared to level
            Alive = true;
            Score = 0;

            //Sets player x & y pos to center of map
            SnakeHead = new GameObject(0, 0);
            if ((LevelWidth / 2) % 2 == 0)
                SnakeHead.X = (LevelWidth / 2) - 1;
            else
                SnakeHead.X = LevelWidth / 2;
            if ((config.LevelHeight / 2) % 2 == 0)
                SnakeHead.Y = (LevelHeight / 2) - 1;
            else
                SnakeHead.Y = LevelHeight / 2;
            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));
            #endregion

            DrawLevel();
            DrawFood();

            DateTime nextLoop = DateTime.Now;

            while (Alive)
            {
                var s1 = new Stopwatch();
                while (nextLoop < DateTime.Now)
                {
                    s1.Start();
                    GetInput();
                    EnactPhysics();

                    nextLoop = nextLoop.AddMilliseconds(1000 / Speed);
                    
                    s1.Stop();
                    Console.SetCursorPosition(30, 5);
                    Console.Write(s1.Elapsed.TotalMilliseconds);

                    if (nextLoop > DateTime.Now) //Anti lag - Program will skip 'sleep' if behind
                    {
                        Thread.Sleep(nextLoop - DateTime.Now);
                        //if(Hardcore)
                            //Thread.Sleep(100);
                    }
                    break;
                }

            }
            Console.WriteLine("Ded");
        }
        private void EnactPhysics()
        {
            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                    SnakeHead.X -= 2;
                    break;
                case ConsoleKey.RightArrow:
                    SnakeHead.X += 2;
                    break;
                case ConsoleKey.DownArrow:
                    SnakeHead.Y += 1;
                    break;
                case ConsoleKey.UpArrow:
                    SnakeHead.Y -= 1;
                    break;
            }

            if (SnakeHead.X <= 0 || SnakeHead.X >= LevelWidth || SnakeHead.Y <= 0 || SnakeHead.Y >= LevelHeight)
            {
                Alive = false;
                return;
            }

            foreach(GameObject part in Snake)
            {
                if (SnakeHead.X == part.X && SnakeHead.Y == part.Y)
                {
                    Alive = false;
                    return;
                }
            }

            if (SnakeHead.X == Food.X && SnakeHead.Y == Food.Y)
            {
                FoodConsumed++;
                DrawFood();
            }

            if (FoodConsumed > 0)
            {
                FoodConsumed--;
                Score++;

                if (Speed < MaxSpeed)
                {
                    Speed = Speed + SpeedIncrease;
                    SpeedCount = SpeedCount + SpeedIncrease;
                }
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor) BackgroundColor;
                Console.SetCursorPosition(Snake.Peek().X, Snake.Peek().Y);
                Console.Write(' ');
                Snake.Dequeue();
            }

            DrawPlayer();

            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));
        }
        private void DrawLevel()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= LevelHeight; i++)
            {
                for (int j = 0; j <= LevelWidth; j++)
                {
                    if (i == 0 || i == LevelHeight)
                    {
                        //Level border
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(Border);
                    }
                    else if (j == 0 || j == LevelWidth)
                    {
                        //Level border
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(Border);
                    }
                    else
                    {
                        //Level Background
                        Console.BackgroundColor = (ConsoleColor)BackgroundColor;
                        Console.Write(' ');
                    }
                }
                Console.Write("\r\n");
            }
        }
        private void DrawPlayer()
        {
            Random random = new Random();

            Console.ForegroundColor = (ConsoleColor)BodyColor;
            foreach(GameObject part in Snake)
            {
                BodyColor = random.Next(0, 15);
                Console.ForegroundColor = (ConsoleColor)BodyColor;
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write(PlayerSkin);
            }

            Console.ForegroundColor = (ConsoleColor)HeadColor;
            Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
            Console.Write(PlayerSkin);
        }
        private void DrawFood()
        {
            bool foodInBadPlace = false;
            do
            {
                Random random = new Random();

                Food.X = random.Next(1, (LevelWidth - 1));
                if (Food.X % 2 == 0)
                    Food.X--;

                Food.Y = random.Next(1, (LevelHeight - 1));

                foreach (GameObject part in Snake)
                {
                    if (part.X == Food.X && part.Y == Food.Y)
                    {
                        foodInBadPlace = true;
                        break;
                    }
                    else
                    {
                        foodInBadPlace = false;
                    }
                }
            } while (foodInBadPlace);

            Console.ForegroundColor = (ConsoleColor) FoodColor;
            Console.SetCursorPosition(Food.X, Food.Y);
            Console.Write('\u25CF');
        }
        private void GetInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;

                switch (Direction)
                {
                    case ConsoleKey.LeftArrow when keyPressed != ConsoleKey.RightArrow:
                    case ConsoleKey.RightArrow when keyPressed != ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow when keyPressed != ConsoleKey.DownArrow:
                    case ConsoleKey.DownArrow when keyPressed != ConsoleKey.UpArrow:
                        Direction = keyPressed;
                        break;

                    case ConsoleKey.Escape:
                        Alive = false;
                        break;
                }
            }
        }
    }
}
