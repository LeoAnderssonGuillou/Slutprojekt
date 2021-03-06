using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    public class Text
    {

        //Writes out player instructions in the beginning of the game
        public static int Instructions(int state, int money)
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
                //Wait for player to have $500, then tell them about the shop
                case 3:
                    if (money >= 500)
                    {
                        state = 4;
                    }
                    break;
                case 4:
                    Text.CenteredText("USE DOWN ARROW KEY", 1000, 50, 250, 0);
                    Text.CenteredText("TO ENTER SHOP", 1000, 50, 330, 0);
                    break;
                default:
                    
                    break;
            }

            //Moves on to the next instruction if enter is pressed. Stops at state 3
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && state < 3)
            {
                state++;
            }
            return state;
        }

        //Method for easily writing out centered text within a given box (centered on x-axis only)
        public static void CenteredText(string text, int fullWidth, int fontSize, int yPos, int xStart)
        {
            Raylib.DrawText(text, xStart + (fullWidth - Raylib.MeasureText(text, fontSize)) / 2, yPos, fontSize, Color.BLACK);
        }

        //Writes out the [PRESS ENTER] instruction
        public static void PressEnter(int y)
        {
            Text.CenteredText("[PRESS ENTER]", 1000, 35, y, 0);
        }

        //Shows the game over screen and restarts the game if enter is pressed
        public static Game GameOverScreen(List<Bullet> bulletList, List<Obstacle> obstacleList, Game game)
        {
            Text.CenteredText("GAME OVER", 1000, 64, 250, 0);
            Text.CenteredText("A FLOPPA HIT THE GROUND", 1000, 40, 350, 0);
            Text.CenteredText("[PRESS ENTER TO PLAY AGAIN]", 1000, 25, 700, 0);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                game.ResetGame();
                bulletList.Clear();
                obstacleList.Clear();
            }
            return game;
        }
    }
}
