using System;

namespace Slutprojekt
{
    public class Game
    {
        public int gameState = 0;
        public int textState = 0;
        public int shootCool = 0;
        public int spawnCool = 0;
        public int money = 0;

        //Resets basic gameplay variables when a new game is started
        public void ResetGame()
        {
            gameState = 0;
            shootCool = 0;
            spawnCool = 0;
            money = 0;
        }

        //Writes out the players money
        public static void ShowMoney(int money)
        {
            Text.CenteredText("$" + money, 100, 26, 10, 0);
        }
    }
}
