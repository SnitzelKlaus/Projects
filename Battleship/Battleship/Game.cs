using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game
    {
        private List<GameObject> Ships = new List<GameObject>();

        //Cursor position
        private GameObject CursorPosition;
        private ConsoleKey Direction;

        #region Player Values
        private bool Alive;
        int CursorColor = 6;
        char CursorBody = '\u25A0';
        #endregion

        #region Level Values
        int LevelHeight = 10;
        int LevelWidth = 20;
        int BorderColor = 7;
        int SelectedBackgroundColor = 1;
        int BackgroundColor = 3;
        char LevelBorder = '\u2588';
        #endregion

        public void RunGame()
        {
            #region Startup
            CursorPosition = new GameObject(0, 0);

            //Sets cursor position in center of map 
            if ((LevelWidth / 2) % 2 == 0)
                CursorPosition.X = (LevelWidth / 2) - 1;
            else
                CursorPosition.X = LevelWidth / 2;
            if ((LevelHeight / 2) % 2 == 0)
                CursorPosition.Y = (LevelHeight / 2) - 1;
            else
                CursorPosition.Y = LevelHeight / 2;

            Alive = true;
            #endregion

            DrawLevel();

            while (Alive)
            {
                GetInput();
                EnactPhysics();
            }
        }

        private void EnactPhysics()
        {
            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                    CursorPosition.X -= 2;
                    break;
                case ConsoleKey.RightArrow:
                    CursorPosition.X += 2;
                    break;
                case ConsoleKey.DownArrow:
                    CursorPosition.Y += 1;
                    break;
                case ConsoleKey.UpArrow:
                    CursorPosition.Y -= 1;
                    break;
            }

            DrawCursor();

        }

        private void DrawLevel()
        {
            Console.SetCursorPosition(0, 0);

            //Draws enemy level
            for (int i = 0; i <= LevelHeight; i++)
            {
                for (int j = 0; j <= LevelWidth; j++)
                {
                    if (i == 0 || i == LevelHeight) //Draws the height of the border
                    {
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(LevelBorder);
                    }
                    else if (j == 0 || j == LevelWidth)  //Draws width of the border
                    {
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(LevelBorder);
                    }
                    else //Draws the background inside the border
                    {
                        Console.BackgroundColor = (ConsoleColor)BackgroundColor;
                        Console.Write(' ');
                    }
                }
                Console.Write("\r\n");
            }

            //Draws player level
            for (int i = 0; i <= LevelHeight; i++)
            {
                for (int j = 0; j <= LevelWidth; j++)
                {
                    if (i == 0 || i == LevelHeight) //Draws the height of the border
                    {
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(LevelBorder);
                    }
                    else if (j == 0 || j == LevelWidth)  //Draws width of the border
                    {
                        Console.ForegroundColor = (ConsoleColor)BorderColor;
                        Console.Write(LevelBorder);
                    }
                    else //Draws the background inside the border
                    {
                        Console.BackgroundColor = (ConsoleColor)SelectedBackgroundColor;
                        Console.Write(' ');
                    }
                }
                Console.Write("\r\n");
            }
        }

        private void DrawCursor()
        {
            Console.BackgroundColor = (ConsoleColor)SelectedBackgroundColor;
            Console.ForegroundColor = (ConsoleColor)CursorColor;
            Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
            Console.Write(CursorBody);
        }

        private void GetInput()
        {
            ConsoleKey keyPressed = Console.ReadKey().Key;

            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    Direction = keyPressed;
                    break;

                case ConsoleKey.Escape:
                    Alive = false;
                    break;

                case ConsoleKey.Enter:
                    Console.Write("Bang!");
                    break;
            }
        }
    }
}
