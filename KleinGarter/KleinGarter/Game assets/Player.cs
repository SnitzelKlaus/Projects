using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace KleinGarter
{
    public class Player
    {
        Config.ConfigData config = Config.GetConfigData(); //Gets config data

        GameObject SnakeHead { get; set; }
        public Queue<GameObject> Snake = new Queue<GameObject>();

        #region Attributes
        public bool Alive { get; set; }
        public int Score { get; set; }
        public int ConsumedFood { get; set; }
        private double Speed { get; set; }
        private int SpeedIncrease
        {
            get
            {
                //This sets how much the speed should increase by, according to size of map and difficulty
                return ((config.MaxSpeed - config.MinSpeed) / ((config.LevelWidth - 2) * (config.LevelHeight - 2))) * config.LevelDifficulty;
            }
        }
        public int SpeedCount { get; set; }
        #endregion

        private ConsoleKey _direction = ConsoleKey.DownArrow;

        public void Movement()
        {
            #region Player start config
            Speed = config.MinSpeed;
            ConsumedFood = config.FoodConsumed;
            Alive = true;
            SnakeHead = new GameObject(0, 0);

            //Sets player x & y pos to center of map
            if ((config.LevelWidth / 2) % 2 == 0)
                SnakeHead.X = (config.LevelWidth / 2) - 1;
            else
                SnakeHead.X = config.LevelWidth / 2;
            if ((config.LevelHeight / 2) % 2 == 0)
                SnakeHead.Y = (config.LevelHeight / 2) - 1;
            else
                SnakeHead.Y = config.LevelHeight / 2;
            #endregion

            DateTime nextLoop = DateTime.Now;

            while (true)
            {
                while (nextLoop < DateTime.Now)
                {

                    if (Console.KeyAvailable)
                    {
                        ConsoleKey keyPressed = Console.ReadKey().Key;

                        switch (_direction)
                        {
                            case ConsoleKey.LeftArrow when keyPressed != ConsoleKey.RightArrow:
                            case ConsoleKey.RightArrow when keyPressed != ConsoleKey.LeftArrow:
                            case ConsoleKey.UpArrow when keyPressed != ConsoleKey.DownArrow:
                            case ConsoleKey.DownArrow when keyPressed != ConsoleKey.UpArrow:
                                _direction = keyPressed;
                                break;
                        }
                    }

                    switch (_direction)
                    {
                        case ConsoleKey.LeftArrow:
                            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));

                            SnakeHead.X--;
                            SnakeHead.X--;
                            break;
                        case ConsoleKey.RightArrow:
                            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));

                            SnakeHead.X++;
                            SnakeHead.X++;
                            break;
                        case ConsoleKey.UpArrow:
                            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));

                            SnakeHead.Y--;
                            break;
                        case ConsoleKey.DownArrow:
                            Snake.Enqueue(new GameObject(SnakeHead.X, SnakeHead.Y));

                            SnakeHead.Y++;
                            break;
                    }
                    DrawPlayer();

                    nextLoop = nextLoop.AddMilliseconds(1000 / Speed);
                    if (nextLoop > DateTime.Now)
                        Thread.Sleep(nextLoop - DateTime.Now);

                    break;
                }
            }
        }

        public void DrawPlayer()
        {
            Food food = new Food();

            var timer = new Stopwatch();
            timer.Start();

            try
            {
                if (SnakeHead.X > 0 && SnakeHead.X < config.LevelWidth && SnakeHead.Y > 0 && SnakeHead.Y < config.LevelHeight && Alive == true)
                {
                    //Body collision
                    foreach (GameObject part in Snake)
                    {
                        if (SnakeHead.X == part.X && SnakeHead.Y == part.Y)
                        {
                            Alive = false;
                        }
                    }

                    //Food
                    if (SnakeHead.X == food.Pos.X && SnakeHead.Y == food.Pos.Y)
                    {
                        ConsumedFood++;
                        food.Raspberry();
                    }

                    if (ConsumedFood > 0)
                    {
                        ConsumedFood--;
                        Score++;

                        if (Speed < config.MaxSpeed)
                        {
                            Speed = Speed + SpeedIncrease;
                            SpeedCount = SpeedCount + SpeedIncrease;
                        }

                        //ScoreBoard
                    }
                    else
                    {
                        //Deletes body
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(Snake.Peek().X, Snake.Peek().Y);
                        Console.Write(' ');
                        Snake.Dequeue();
                    }

                    //Draws snake body
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    foreach (GameObject part in Snake)
                    {
                        Console.SetCursorPosition(part.X, part.Y);
                        Console.Write(config.PlayerSkin);
                    }

                    //Draws snake head
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
                    Console.Write(config.PlayerSkin);
                    Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
                }
                else if (Alive == false)
                {
                    Console.WriteLine("ded");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nope");
            }

            timer.Stop();
            Console.SetCursorPosition(config.LevelWidth + 5, 15);
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
        }
    }
}
