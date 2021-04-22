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
            //Setup
            Raylib.InitWindow(1000, 800, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            //Lists of objects
            List<Bullet> bullets = new List<Bullet>();
            List<Obstacle> obstacles = new List<Obstacle>();

            //Aiming variables
            Vector2 direction = new Vector2(0, 0);
            float aimAngle = 0;

            //Cooldown variables
            int shootCool = 0;
            int spawnCool = 0;

            //Random
            Random random = new Random();

            while (!Raylib.WindowShouldClose())
            {
                //Setup frame
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                Texture2D walter = Raylib.LoadTexture("walter.png");
                Texture2D walter2 = Raylib.LoadTexture("walter2.png");


                //Spawns obstacles
                spawnCool = Spawn(spawnCool, obstacles);

                //Draw and move objetcs
                HandleObjects(bullets, obstacles);

                //Aim with arrow keys
                aimAngle = Aim(aimAngle, direction.X, direction.Y);

                //Translate aimAngle to x and y values for bullet starting position and speed
                direction = AngleToDirection(direction, aimAngle);

                //Draw aiming indicator
                AimIndicator(direction, walter);

                //Shoot bullet
                shootCool = ShootBullet(bullets, direction, walter2, shootCool);


                Raylib.EndDrawing();

            }


        }

        //Spawn obstacles
        static int Spawn(int cool, List<Obstacle> enemys)
        {
            if (cool == 0)
            {
                Random rand = new Random();
                int x = rand.Next(0, 1001);
                int xSpeed = rand.Next(10, 31)/10;
                int ySpeed = rand.Next(10, 31)/10;
                enemys.Add(new Obstacle(x, 0, xSpeed, ySpeed, 5));
                cool = 100;
            }
            cool--;
            return cool;
        }

        //Draw/move objects and handle collisions
        static void HandleObjects(List<Bullet> bulletList, List<Obstacle> obstacleList)
        {
            //Draw/move bullets
            foreach (Bullet shot in bulletList)
                {
                    Raylib.DrawCircle((int)shot.pos.X, (int)shot.pos.Y, 15, Color.GREEN);
                    shot.pos.X += shot.xSpeed / 8;
                    shot.pos.Y -= shot.ySpeed / 8;
                }
            
            //Draw/move obstacles and check all possible collisions
            //To remove objects from these lists using loops, it is required to go through a for-loop in reverse
            for (int i = obstacleList.Count - 1; i >= 0; i--)
                {
                    Obstacle enemy = obstacleList[i];
                    int size = 80;
                    enemy.color = new Color(255, enemy.red, enemy.red, 255);
                    enemy.box = new Rectangle(enemy.pos.X, enemy.pos.Y, size, size);
                    Raylib.DrawTexture(enemy.image, (int)enemy.pos.X, (int)enemy.pos.Y, enemy.color);
                    enemy.pos.X += enemy.xSpeed;
                    enemy.pos.Y += enemy.ySpeed;

                    //If collision is detected, remove bullet and damage obstacle.
                    for (int x = bulletList.Count - 1; x >= 0; x--)
                        {
                            if (Raylib.CheckCollisionCircleRec(bulletList[x].pos, 15, enemy.box))
                            {
                                bulletList.RemoveAt(x);
                                enemy.hp -= 1;
                                enemy.red = 155;
                            }
                        }

                    //Make obstacle less red, if red less than 0, make red 0
                    enemy.red += 15;
                    if (enemy.red > 255)
                    {
                        enemy.red = 255;
                    }

                    //Remove obstacle if its HP is 0
                    if (enemy.hp < 1)
                    {
                        obstacleList.Remove(enemy);
                    }
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
        static int ShootBullet(List<Bullet> bulletList, Vector2 direc, Texture2D character, int cool)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    Raylib.DrawTexture(character, 455, 690, Color.WHITE);
                    if (cool < 1)
                    {
                        int aimX = (int)(500 + direc.X);
                        int aimY = (int)(750 - direc.Y);
                        bulletList.Add(new Bullet(aimX, aimY, direc.X, direc.Y));
                        cool = 4;
                    }
                }
                cool--;
                return cool;
        }

    }
}
