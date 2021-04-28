using System;
using Raylib_cs;

namespace Slutprojekt
{
    public class Text
    {

        public static void Instructions(int state)
        {
            switch (state)
            {
                case 0:
                    Text.CenteredText("WELCOME TO WALTER GAME", 1000, 64, 150, 0);
                    Text.CenteredText("[PRESS ENTER]", 1000, 35, 270, 0);
                    break;
                case 1:
                    
                    break;
            }
        }


        public static void CenteredText(string text, int fullWidth, int fontSize, int yPos, int xStart)
        {
            Raylib.DrawText(text, xStart + (fullWidth - Raylib.MeasureText(text, fontSize)) / 2, yPos, fontSize, Color.BLACK);
        }
    }
}
