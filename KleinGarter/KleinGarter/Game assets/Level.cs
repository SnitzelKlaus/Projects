using System;
using System.Collections.Generic;
using System.Text;

namespace KleinGarter
{
    class Level
    {
        Config.ConfigData config = Config.GetConfigData(); //Gets config data

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= config.LevelHeight; i++)
            {
                for (int j = 0; j <= config.LevelWidth; j++)
                {
                    if (i == 0 || i == config.LevelHeight)
                    {
                        //Level border
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(config.Border);
                    }
                    else if (j == 0 || j == config.LevelWidth)
                    {
                        //Level border
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(config.Border);
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

            Food food = new Food();
            food.Raspberry();
        }
    }
}
