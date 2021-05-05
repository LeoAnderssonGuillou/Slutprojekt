using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    public class Shop
    {
        public static void SetupShop(Color border, Game game)
        {
            game.upgradeCost = 500 + 100 * game.timesUpgraded;
            if (game.money >= game.upgradeCost)
            {
                border = Color.GREEN;
                if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
                {
                    border = Color.YELLOW;
                }
            }
            int xPos = 425;
            int yPos = 325;
            Raylib.DrawRectangle(xPos, yPos, 150, 150, border);
            Raylib.DrawRectangle(xPos + 5, yPos + 5, 140, 140, Color.LIGHTGRAY);
            Text.CenteredText("FASTER", 150, 24, 375, xPos);
            Text.CenteredText("RELOAD", 150, 24, 396, xPos);
            Text.CenteredText("SHOP", 1000, 66, 45, 0);
            Text.CenteredText("PRESS 1 TO BUY UPGRADE", 1000, 35, 125, 0);
            Text.CenteredText("COST: $" + game.upgradeCost, 1000, 25, 500, 0);
            Text.CenteredText("PRESS DOWN TO EXIT", 1000, 35, 720, 0);
        }
        
        //Enter/exit shop
        public static void ToggleShop(Game game)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && game.textState > 2)
            {
                if (game.gameState == 0)
                {
                    game.gameState = 1;
                    game.textState = 5;
                }
                else
                {
                    game.gameState = 0;
                }
            }
        }

        public static void BuyStuff(Game game, Gun gun)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && game.money >= 500)
            {
                game.money -= game.upgradeCost;
                game.timesUpgraded++;
                gun.reload -= 1;
            }
        }
    }
}
