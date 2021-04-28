using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    public class Shop
    {
        public static void SetupShop(Color border, int money)
        {
            if (money >= 100)
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
        }
        
        //Enter/exit shop
        public static void ToggleShop(Game game)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
            {
                if (game.gameState == 0)
                {
                    game.gameState = 1;
                }
                else
                {
                    game.gameState = 0;
                }
            }
        }

        public static void BuyStuff(Game game, Gun gun)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && game.money >= 100)
            {
                game.money -= 100;
                gun.reload -= 1;
            }
        }
    }
}
