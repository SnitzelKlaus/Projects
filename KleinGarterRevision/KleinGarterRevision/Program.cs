﻿using System;
using System.Xml.Serialization;
using System.IO;

namespace KleinGarterRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets console values
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            //Start of program
            GUI gui = new GUI();
            int interactionID = gui.InteractionMenu();

            switch (interactionID)
            {
                case 1: //Start game
                    Game game = new Game();
                    game.RunGame();

                    break;
                case 2: //Settings
                    gui.Settings();
                    break;
            }
        }
    }
}
