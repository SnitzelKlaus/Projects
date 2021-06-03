using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets console values
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            Game game = new Game();

            game.RunGame();
        }
    }
}
