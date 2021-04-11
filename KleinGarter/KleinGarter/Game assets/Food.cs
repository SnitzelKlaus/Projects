using System;
using System.Collections.Generic;
using System.Text;

namespace KleinGarter
{
    class Food
    {
        public GameObject Pos = new GameObject(0, 0);

        //Food position
        private int X { get; set; }
        private int Y { get; set; }

        //Generates random x position
        public int RandomXPos()
        {
            Config.ConfigData config = Config.GetConfigData();
            Random random = new Random();
            int i = random.Next(1, config.LevelWidth - 1);
            if (i % 2 == 0)
            {
                i--;
            }
            return i;
        } 

        //Generates random y position
        public int RandomYPos()
        {
            Config.ConfigData config = Config.GetConfigData();
            Random random = new Random();
            int i = random.Next(1, config.LevelHeight - 1);
            if (i % 2 == 0)
            {
                i--;
            }
            return i;
        }

        //Generates valid x y position for food
        private void GeneratePosition()
        {
            Player player = new Player();
            bool foodInBadPlace = true;

            do
            {
                X = RandomXPos();
                Y = RandomYPos();

                foreach (GameObject part in player.Snake)
                {
                    if (X == part.X && Y == part.Y)
                    {
                        foodInBadPlace = true;
                        break;
                    }
                    else
                    {
                        foodInBadPlace = false;
                    }
                }
            } while (!foodInBadPlace);
        }

        public void Raspberry()
        {
            GeneratePosition();
            Pos.X = X;
            Pos.Y = Y;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(X, Y);
            Console.Write('\u25CF');

            Pos.X = X;
            Pos.Y = Y;
        }
    }
}
