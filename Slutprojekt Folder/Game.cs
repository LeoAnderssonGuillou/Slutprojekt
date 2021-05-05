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
        public int upgradeCost = 0;
        public int timesUpgraded = 0;
        public int level = 0;
        public int levelCool = 60;

        //Resets basic gameplay variables when a new game is started
        public void ResetGame()
        {
            gameState = 0;
            shootCool = 0;
            spawnCool = 0;
            money = 0;
            timesUpgraded = 0;
            level = 0;
            levelCool = 60;
        }

        //Writes out the players money
        public static void ShowMoney(int money)
        {
            Text.CenteredText("$" + money, 100, 30, 10, 0);
        }

        public static void Clock(Game game)
        {
            game.levelCool--;
            if (game.levelCool < 0)
            {
                game.level++;
                game.levelCool = 60;
            }
        }
    }
}
