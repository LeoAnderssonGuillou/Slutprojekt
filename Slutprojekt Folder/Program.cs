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


            List<Bullet> bullets = new List<Bullet>();
            // bullets.Add(new Bullet(500, 780, 1, 1));
            // bullets.Add(new Bullet(600, 600, 1, 1));

            float directionX = 0;
            float directionY = 90;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Texture2D walter = Raylib.LoadTexture("walter.png");



                foreach (Bullet shot in bullets)
                {
                    Raylib.DrawTexture(walter, (int)shot.x, (int)shot.y, Color.WHITE);
                    //Raylib.DrawCircle((int)shot.x, (int)shot.y, 20, Color.RED);
                    shot.x += shot.xSpeed / 10;
                    shot.y -= shot.ySpeed / 10;
                }


                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && directionX < 90)
                {
                    directionX += 3;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && directionX > -90)
                {
                    directionX -= 3;
                }
                directionY = 90 - directionX * directionX / 90;

                if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    bullets.Add(new Bullet(500, 600, directionX, directionY));
                }



                //Console.WriteLine("Y: " + directionY);
                //Console.WriteLine("X: " + directionX);


                Raylib.EndDrawing();

            }


        }
    }
}
