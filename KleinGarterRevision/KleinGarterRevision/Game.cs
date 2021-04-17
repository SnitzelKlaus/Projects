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
        private GameObject SnakeHead;
        private Queue<GameObject> Snake = new Queue<GameObject>();
        private GameObject Food;
        private bool Alive = true;
        private int Score;
        private int FoodConsumed;
        private double Speed;
        private double SpeedIncrease;
        private double SpeedCount;


        private char PlayerSkin => config.PlayerSkin;
        private int MinSpeed => config.MinSpeed;
        private int MaxSpeed => config.MaxSpeed;
        private char Border => config.Border;
        private int BorderColor => config.BorderColor;
        private int LevelWidth => config.LevelWidth;
        private int LevelHeight => config.LevelHeight;
        private int LevelDifficulty => config.LevelDifficulty;
        #endregion

        public void RunGame()
        {
            #region Start configuration
            Food = new GameObject(0, 0);
            FoodConsumed = config.FoodConsumed;
            Speed = MinSpeed;
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
            #endregion

            DrawLevel();
            DrawFood();

            DateTime nextLoop = DateTime.Now;

            while (Alive)
            {
                while (nextLoop < DateTime.Now)
                {
                    GetInput();
                    EnactPhysics();

                    nextLoop = nextLoop.AddMilliseconds(1000 / Speed);
                    if (nextLoop > DateTime.Now)
                        Thread.Sleep(nextLoop - DateTime.Now);

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

            if(SnakeHead.X == Food.X && SnakeHead.Y == Food.Y)
            {
                FoodConsumed++;
                DrawFood();
            }

            if(FoodConsumed > 0)
            {
                FoodConsumed--;
                Score++;

                if(Speed < MaxSpeed)
                {
                    Speed = Speed + SpeedIncrease;
                    SpeedCount = SpeedCount + SpeedIncrease;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(Snake.Peek().X, Snake.Peek().Y);
                Console.Write(' ');
                Snake.Dequeue();
            }

            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));

            DrawPlayer();
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
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(Border);
                    }
                    else if (j == 0 || j == LevelWidth)
                    {
                        //Level border
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(Border);
                    }
                    else
                    {
                        //Level Background
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(' ');
                    }
                }
                Console.Write("\r\n");
            }
        }
        private void DrawPlayer()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach(GameObject part in Snake)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write(PlayerSkin);
            }

            Console.ForegroundColor = ConsoleColor.Black;
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
                {
                    Food.X--;
                }
                Food.Y = random.Next(1, (LevelHeight - 1));

                foreach (GameObject part in Snake)
                {
                    if (part.X == Food.X && part.Y == Food.Y)
                    {
                        foodInBadPlace = true;
                    }
                    else
                    {
                        foodInBadPlace = false;
                    }
                }
            } while (foodInBadPlace);

            Console.ForegroundColor = ConsoleColor.DarkRed;
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
