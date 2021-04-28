using System;

namespace Slutprojekt
{
    public class Game
    {
        public bool gameOver = false;
        public int textState = 0;
        public int shootCool = 0;
        public int spawnCool = 0;

        public void ResetGame()
        {
            gameOver = false;
            shootCool = 0;
            spawnCool = 0;
        }
    }
}
