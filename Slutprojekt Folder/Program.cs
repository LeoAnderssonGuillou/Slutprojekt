using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

namespace Slutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 800, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            //Lists of objects
            List<Bullet> bullets = new List<Bullet>();
            List<Obstacle> obstacles = new List<Obstacle>();

            //Aiming variables
            Vector2 direction = new Vector2(0, 0);
            float aimAngle = 0;

            obstacles.Add(new Obstacle(500, 50, 1, 10));

            while (!Raylib.WindowShouldClose())
            {
                //Setup
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Texture2D walter = Raylib.LoadTexture("walter.png");
                Texture2D walter2 = Raylib.LoadTexture("walter2.png");


                //Draw and move bullets
                HandleObjects(bullets, obstacles);

                //Aim with arrow keys
                aimAngle = Aim(aimAngle, direction.X, direction.Y);

                //Translate aimAngle to x and y values for bullet starting position and speed
                direction = AngleToDirection(direction, aimAngle);

                //Draw aiming indicator
                AimIndicator(direction, walter);

                //Shoot bullet
                ShootBullet(bullets, direction, walter2);


                Raylib.EndDrawing();

            }


        }

        //Draw and move bullets
        static void HandleObjects(List<Bullet> bulletList, List<Obstacle> obstacleList)
        {
            foreach (Bullet shot in bulletList)
                {
                    Raylib.DrawCircle((int)shot.pos.X, (int)shot.pos.Y, 15, Color.RED);
                    shot.pos.X += shot.xSpeed / 10;
                    shot.pos.Y -= shot.ySpeed / 10;
                }
            
            foreach (Obstacle enemy in obstacleList)
                {
                    Raylib.DrawCircle((int)enemy.pos.X, (int)enemy.pos.Y, 15, Color.RED);
                    enemy.pos.X += enemy.xSpeed;
                    enemy.pos.Y += enemy.ySpeed;
                }
        }

        //Aim with arrow keys
        static float Aim(float angle, float direcX, float direcY)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && direcX < 90)
                {
                    angle += 3;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && direcX > -90)
                {
                    angle -= 3;
                }
                return angle;
        }

        //Translate aimAngle to x and y values for bullet starting position and speed
        static Vector2 AngleToDirection(Vector2 direc, float angle)
        {
            direc.X = MathF.Sin(angle * MathF.PI / 180) * 90;
            direc.Y = MathF.Cos(angle * MathF.PI / 180) * 90;
            return direc;
        }

        //Draw aiming indicator and character
        static void AimIndicator(Vector2 direc, Texture2D character)
        {
            int aimX = (int)(500 + direc.X);
            int aimY = (int)(750 - direc.Y);
            Raylib.DrawCircle(aimX, aimY, 20, Color.BLACK);
            Raylib.DrawTexture(character, 455, 690, Color.WHITE);
        }

        //Create new bullet and draw character shooting
        static void ShootBullet(List<Bullet> bulletList, Vector2 direc, Texture2D character)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    int aimX = (int)(500 + direc.X);
                    int aimY = (int)(750 - direc.Y);
                    bulletList.Add(new Bullet(aimX, aimY, direc.X, direc.Y));
                    Raylib.DrawTexture(character, 455, 690, Color.WHITE);
                }
        }

    }
}
