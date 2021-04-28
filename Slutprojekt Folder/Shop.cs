using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    public class Shop
    {

        public static void SetupShop(Color border)
        {
            int xPos = 425;
            int yPos = 325;
            Raylib.DrawRectangle(xPos, yPos, 150, 150, border);
            Raylib.DrawRectangle(xPos + 5, yPos + 5, 140, 140, Color.LIGHTGRAY);
            Text.CenteredText("FASTER", 150, 24, 375, xPos);
            Text.CenteredText("RELOAD", 150, 24, 396, xPos);
        }
    }
}
