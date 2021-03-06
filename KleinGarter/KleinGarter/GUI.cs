using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KleinGarter
{
    class GUI
    {
        public int InteractionMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t" + @"       ____  __.__         .__             ");
            Console.WriteLine("\t" + @"      |    |/ _|  |   ____ |__| ____       ");
            Console.WriteLine("\t" + @"      |      < |  | _/ __ \|  |/    \      ");
            Console.WriteLine("\t" + @"      |    |  \|  |_\  ___/|  |   |  \     ");
            Console.WriteLine("\t" + @"      |____|__ \____/\___  >__|___|  /     ");
            Console.WriteLine("\t" + @"              \/         \/        \/      ");
            Console.WriteLine("\t" + @"  ________               __                ");
            Console.WriteLine("\t" + @" /  _____/_____ ________/  |_  ___________ ");
            Console.WriteLine("\t" + @"/   \  ___\__  \\_  __ \   __\/ __ \_  __ \");
            Console.WriteLine("\t" + @"\    \_\  \/ __ \|  | \/|  | \  ___/|  | \/");
            Console.WriteLine("\t" + @" \______  (____  /__|   |__|  \___  >__|   ");
            Console.WriteLine("\t" + @"        \/     \/                 \/       ");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\t+------------------+   +------------------+");
            Console.WriteLine("\t|    Start Game    |   |     Settings     |");
            Console.WriteLine("\t+------------------+   +------------------+");

            int interactionID;
            var _direction = Console.ReadKey().Key;

            while (true)
            {
                switch (_direction)
                {
                    case ConsoleKey.LeftArrow:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(8, 15);
                        Console.WriteLine("+------------------+");
                        Console.SetCursorPosition(8, 16);
                        Console.WriteLine("|    Start Game    |");
                        Console.SetCursorPosition(8, 17);
                        Console.WriteLine("+------------------+");

                        if (Console.KeyAvailable)
                        {
                            _direction = Console.ReadKey().Key;

                            if (_direction == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                interactionID = 1;
                                return interactionID;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(8, 15);
                                Console.WriteLine("+------------------+");
                                Console.SetCursorPosition(8, 16);
                                Console.WriteLine("|    Start Game    |");
                                Console.SetCursorPosition(8, 17);
                                Console.WriteLine("+------------------+");
                            }
                        }
                        break;


                    case ConsoleKey.RightArrow:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(31, 15);
                        Console.WriteLine("+------------------+");
                        Console.SetCursorPosition(31, 16);
                        Console.WriteLine("|     Settings     |");
                        Console.SetCursorPosition(31, 17);
                        Console.WriteLine("+------------------+");

                        if (Console.KeyAvailable)
                        {
                            _direction = Console.ReadKey().Key;

                            if (_direction == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                interactionID = 2;
                                return interactionID;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(31, 15);
                                Console.WriteLine("+------------------+");
                                Console.SetCursorPosition(31, 16);
                                Console.WriteLine("|     Settings     |");
                                Console.SetCursorPosition(31, 17);
                                Console.WriteLine("+------------------+");
                            }
                        }
                        break;

                    default:
                        if (Console.KeyAvailable)
                        {
                            _direction = Console.ReadKey().Key;
                        }
                        break;
                }
            }
        }

        public void SettingsMenu()
        {
            Config.ConfigData config = Config.GetConfigData(); //Gets config data
            List<string> valueName = new List<string>();

            valueName.Add("PlayerSkin");
            valueName.Add("FoodConsumed");
            valueName.Add("MinSpeed");
            valueName.Add("MaxSpeed");
            valueName.Add("Border");
            valueName.Add("LevelWidth");
            valueName.Add("LevelDifficulty");
            valueName.Add("BorderColor");
            valueName.Add("BackgroundColor");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t" + @"  _________       __    __  .__                      ");
            Console.WriteLine("\t" + @" /   _____/ _____/  |__/  |_|__| ____    ____  ______");
            Console.WriteLine("\t" + @" \_____  \_/ __ \   __\   __\  |/    \  / ___\/  ___/");
            Console.WriteLine("\t" + @" /        \  ___/|  |  |  | |  |   |  \/ /_/  >___ \ ");
            Console.WriteLine("\t" + @"/_______  /\___  >__|  |__| |__|___|  /\___  /____  >");
            Console.WriteLine("\t" + @"        \/     \/                   \//_____/     \/ ");

            int interactionID = 0;
            var move = Console.ReadKey().Key;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey().Key;

                    switch (move)
                    {
                        case ConsoleKey.UpArrow when interactionID ! > valueName.Count:
                        case ConsoleKey.DownArrow when interactionID! < valueName.Count:
                            move = keyPressed;
                            break;
                    }
                }


            }
        }
    }
}
