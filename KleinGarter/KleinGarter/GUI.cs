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
            var move = Console.ReadKey().Key;

            while (true)
            {
                switch (move)
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
                            move = Console.ReadKey().Key;

                            if (move == ConsoleKey.Enter)
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
                            move = Console.ReadKey().Key;

                            if (move == ConsoleKey.Enter)
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
                            move = Console.ReadKey().Key;
                        }
                        break;
                }
            }
        }
    }
}
