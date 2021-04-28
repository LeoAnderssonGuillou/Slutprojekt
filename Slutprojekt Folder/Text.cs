using System;
using Raylib_cs;

namespace Slutprojekt
{
    public class Text
    {

        public static int Instructions(int state)
        {
            switch (state)
            {
                case 0:
                    Text.CenteredText("WELCOME TO WALTER GAME", 1000, 64, 150, 0);
                    Text.PressEnter(270);
                    break;
                case 1:
                    Text.CenteredText("AIM WITH ARROW KEYS", 1000, 64, 150, 0);
                    Text.CenteredText("SHOOT WITH SPACE", 1000, 64, 275, 0);
                    Text.PressEnter(400);
                    break;
                case 2:
                    Text.CenteredText("STOP FLOPPAS FROM", 1000, 64, 150, 0);
                    Text.CenteredText("HITTING THE GROUND", 1000, 64, 250, 0);
                    Text.PressEnter(375);
                    break;
                default:
                    
                    break;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                state++;
                Console.WriteLine(state);
            }
            return state;
        }


        public static void CenteredText(string text, int fullWidth, int fontSize, int yPos, int xStart)
        {
            Raylib.DrawText(text, xStart + (fullWidth - Raylib.MeasureText(text, fontSize)) / 2, yPos, fontSize, Color.BLACK);
        }

        public static void PressEnter(int y)
        {
            Text.CenteredText("[PRESS ENTER]", 1000, 35, y, 0);
        }
    }
}
