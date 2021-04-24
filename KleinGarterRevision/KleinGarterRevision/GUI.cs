using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KleinGarterRevision
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

        private List<string> Settings = new List<string>();
        private List<string> Data = new List<string>();

        public void SettingsMenu()
        {
            Config.ConfigData config = Config.GetConfigData(); //Gets config data

            if (Settings.Count == 0)
            {
                #region Settings values
                Settings.Add("Hardcore");
                Settings.Add("FoodConsumed");
                Settings.Add("LevelWidth");
                Settings.Add("LevelHeight");
                Settings.Add("LevelDifficulty");
                Settings.Add("HeadColor");
                Settings.Add("BodyColor");
                Settings.Add("FoodColor");
                Settings.Add("BorderColor");
                Settings.Add("BackgroundColor");
                #endregion
                #region Data values
                Data.Add(Convert.ToString("<" + config.Hardcore + ">"));
                Data.Add(Convert.ToString("<" + config.FoodConsumed + ">"));
                Data.Add(Convert.ToString("<" + config.LevelWidth + ">"));
                Data.Add(Convert.ToString("<" + config.LevelHeight + ">"));
                Data.Add(Convert.ToString("<" + config.LevelDifficulty + ">"));
                Data.Add(Convert.ToString("<" + config.HeadColor + ">"));
                Data.Add(Convert.ToString("<" + config.BodyColor + ">"));
                Data.Add(Convert.ToString("<" + config.FoodColor + ">"));
                Data.Add(Convert.ToString("<" + config.BorderColor + ">"));
                Data.Add(Convert.ToString("<" + config.BackgroundColor + ">"));
                #endregion
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t" + @"  _________       __    __  .__                      ");
            Console.WriteLine("\t" + @" /   _____/ _____/  |__/  |_|__| ____    ____  ______");
            Console.WriteLine("\t" + @" \_____  \_/ __ \   __\   __\  |/    \  / ___\/  ___/");
            Console.WriteLine("\t" + @" /        \  ___/|  |  |  | |  |   |  \/ /_/  >___ \ ");
            Console.WriteLine("\t" + @"/_______  /\___  >__|  |__| |__|___|  /\___  /____  >");
            Console.WriteLine("\t" + @"        \/     \/                   \//_____/     \/ ");
            Console.WriteLine("\t" + @"-----------------------------------------------------");

            for (int i = 0; i < Settings.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                WriteSetting(i);
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("ESC = EXIT");
            Console.WriteLine("ENTER = SAVES CONFIG");
            Console.WriteLine("TAB = DEFAULT CONFIG");

            int tmp;
            int interactionID = 0;
            ConsoleKey direction = ConsoleKey.UpArrow;

            #region Highlights start position
            Console.ForegroundColor = ConsoleColor.White;
            WriteSetting(interactionID);
            #endregion

            while (direction != ConsoleKey.Escape)
            {
                if (Console.KeyAvailable)
                {
                    direction = Console.ReadKey().Key;

                    switch (direction)
                    {
                        case ConsoleKey.LeftArrow:
                            switch (interactionID)
                            {
                                case 0:
                                    config.Hardcore = false;
                                    Data[interactionID] = "<False>";

                                    WriteSetting(interactionID);
                                    break;
                                case 1:
                                    if (config.FoodConsumed > 0)
                                        config.FoodConsumed--;

                                    Data[interactionID] = $"<{config.FoodConsumed}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 2:
                                    if (config.LevelWidth > 8)
                                        config.LevelWidth -= 2;

                                    Data[interactionID] = $"<{config.LevelWidth}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 3:
                                    if (config.LevelHeight > 4)
                                        config.LevelHeight--;

                                    Data[interactionID] = $"<{config.LevelHeight}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 4:
                                    if (config.LevelDifficulty > 0)
                                        config.LevelDifficulty--;

                                    Data[interactionID] = $"<{config.LevelDifficulty}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 5:
                                    if (config.HeadColor > 0)
                                        config.HeadColor--;

                                    Data[interactionID] = $"<{config.HeadColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 6:
                                    if (config.BodyColor > 0)
                                        config.BodyColor--;

                                    Data[interactionID] = $"<{config.BodyColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 7:
                                    if (config.FoodColor > 0)
                                        config.FoodColor--;

                                    Data[interactionID] = $"<{config.FoodColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 8:
                                    if (config.BorderColor > 0)
                                        config.BorderColor--;

                                    Data[interactionID] = $"<{config.BorderColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 9:
                                    if (config.BackgroundColor > 0)
                                        config.BackgroundColor--;

                                    Data[interactionID] = $"<{config.BackgroundColor}>";

                                    WriteSetting(interactionID);
                                    break;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            switch (interactionID)
                            {
                                case 0:
                                    config.Hardcore = true;
                                    Data[interactionID] = "<True>";

                                    WriteSetting(interactionID);
                                    break;
                                case 1:
                                    if (config.FoodConsumed < (config.LevelWidth * config.LevelHeight))
                                        config.FoodConsumed++;

                                    Data[interactionID] = $"<{config.FoodConsumed}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 2:
                                        config.LevelWidth += 2;

                                    Data[interactionID] = $"<{config.LevelWidth}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 3:
                                        config.LevelHeight++;

                                    Data[interactionID] = $"<{config.LevelHeight}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 4:
                                    if (config.LevelDifficulty < 10)
                                        config.LevelDifficulty++;

                                    Data[interactionID] = $"<{config.LevelDifficulty}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 5:
                                    if (config.HeadColor < 15)
                                        config.HeadColor++;

                                    Data[interactionID] = $"<{config.HeadColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 6:
                                    if (config.BodyColor < 15)
                                        config.BodyColor++;

                                    Data[interactionID] = $"<{config.BodyColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 7:
                                    if (config.FoodColor < 15)
                                        config.FoodColor++;

                                    Data[interactionID] = $"<{config.FoodColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 8:
                                    if (config.BorderColor < 15)
                                        config.BorderColor++;

                                    Data[interactionID] = $"<{config.BorderColor}>";

                                    WriteSetting(interactionID);
                                    break;
                                case 9:
                                    if (config.BackgroundColor < 15)
                                        config.BackgroundColor++;

                                    Data[interactionID] = $"<{config.BackgroundColor}>";

                                    WriteSetting(interactionID);
                                    break;
                            }
                            break;
                        case ConsoleKey.DownArrow when interactionID <= Settings.Count - 1:
                            tmp = interactionID;
                            if(interactionID != Settings.Count - 1)
                                interactionID++;

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            WriteSetting(tmp);

                            Console.ForegroundColor = ConsoleColor.White;
                            WriteSetting(interactionID);

                            break;
                        case ConsoleKey.UpArrow when interactionID >= 0:
                            tmp = interactionID;
                            if (interactionID != 0)
                                interactionID--;

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            WriteSetting(tmp);

                            Console.ForegroundColor = ConsoleColor.White;
                            WriteSetting(interactionID);

                            break;
                        case ConsoleKey.Enter:
                            Config.SaveConfigData(config);
                            break;
                    }
                }
            }
        }

        private void WriteSetting(int id)
        {
            Console.SetCursorPosition(8, id + 8);
            Console.Write($"{Settings[id]}:");
            Console.SetCursorPosition(51, id + 8);
            Console.Write(Data[id].PadLeft(10));
        }
    }
}
