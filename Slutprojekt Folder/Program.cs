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

            bullets.Add(new Bullet(500, 780));
            bullets.Add(new Bullet(600, 600));

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);


                foreach (Bullet shot in bullets)
                {
                    Raylib.DrawCircle((int)shot.x, (int)shot.y, 20, Color.RED);
                    shot.x -= 1;
                    shot.y -= 2;
                }



                Raylib.EndDrawing();

            }


        }
    }
}
