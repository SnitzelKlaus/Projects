using System;
using System.Collections.Generic;
using System.Text;

namespace KleinGarter
{
    class Game
    {
        public void SnakeGame()
        {
            GUI gui = new GUI(); //Graphical user interface
            Level level = new Level();
            Player player = new Player();

            int interactionID = gui.InteractionMenu(); //Gets intaraction input from user (used for navigating menu)

            switch (interactionID)
            {
                case 1: //Start game
                    level.Draw();
                    player.Movement();

                    break;
                case 2: //Settings
                    
                    break;
            }
        }
    }
}
