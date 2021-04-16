using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 800, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            //List of bullets
            List<Bullet> bullets = new List<Bullet>();
            // bullets.Add(new Bullet(500, 780, 1, 1));
            // bullets.Add(new Bullet(600, 600, 1, 1));

            //Aiming
            float directionX = 0;
            float directionY = 90;

            while (!Raylib.WindowShouldClose())
            {
                //Setup
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Texture2D walter = Raylib.LoadTexture("walter.png");
                Texture2D walter2 = Raylib.LoadTexture("walter2.png");

                //Draw and move bullets
                foreach (Bullet shot in bullets)
                {
                    //Raylib.DrawTexture(walter, (int)shot.x, (int)shot.y, Color.WHITE);
                    Raylib.DrawCircle((int)shot.x, (int)shot.y, 20, Color.RED);
                    shot.x += shot.xSpeed / 10;
                    shot.y -= shot.ySpeed / 10;
                }


                //Aim with arrow keys
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && directionX < 90)
                {
                    directionX += 3;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && directionX > -90)
                {
                    directionX -= 3;
                }
                directionY = 90 - directionX * directionX / 90;


                //Draw aiming indicator
                int aimX = (int)(500 + directionX);
                int aimY = (int)(600 - directionY);
                Raylib.DrawCircle(aimX, aimY, 20, Color.BLACK);
                Raylib.DrawTexture(walter, 455, 540, Color.WHITE);


                // Raylib.DrawCircle((int)(500 + directionX / 2), (int)(600 - directionY / 2), 20, Color.BLACK);
                // Raylib.DrawCircle((int)(500), (int)(600), 20, Color.BLACK);


                //Shoot bullet
                if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    bullets.Add(new Bullet(aimX, aimY, directionX, directionY));
                    Raylib.DrawTexture(walter2, 455, 540, Color.WHITE);
                }

                //TEST

                //Console.WriteLine("Y: " + directionY);
                //Console.WriteLine("X: " + directionX);


                Raylib.EndDrawing();

            }


        }
    }
}
