using System;
using System.Xml.Serialization;
using System.IO;

namespace KleinGarter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets console values
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            //Start game
            Game game = new Game();
            game.SnakeGame();
        }
    }
}
