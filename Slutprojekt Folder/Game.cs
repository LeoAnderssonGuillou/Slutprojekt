using System;

namespace Slutprojekt
{
    public class Game
    {
        public int gameState = 1;
        public int textState = 0;
        public int shootCool = 0;
        public int spawnCool = 0;

        public void ResetGame()
        {
            gameState = 0;
            shootCool = 0;
            spawnCool = 0;
        }
    }
}
