using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

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

            //Textues
            Texture2D walter = Raylib.LoadTexture("walter.png");
            Texture2D walter2 = Raylib.LoadTexture("walter2.png");
            Texture2D floppa = Raylib.LoadTexture("floppa.png");

            //Miscellaneous
            Game game = new Game();
            Color borderColor = Color.RED;


            while (!Raylib.WindowShouldClose())
            {
                //Setup frame
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                
                //Standard gameplay mode
                if (game.gameState == 0)
                {
                    game.spawnCool = Obstacle.Spawn(game.spawnCool, obstacles, floppa, game);                    //Spawns obstacles
                    HandleObjects(bullets, obstacles, game);                                                     //Draw and move objetcs
                    aimAngle = Aim(aimAngle, direction.X, direction.Y);                                          //Aim with arrow keys?
                    direction = AngleToDirection(direction, aimAngle);                                           //Translate aimAngle to x and y values for bullet starting position and speed
                    AimIndicator(direction, walter);                                                             //Draw aiming indicator
                    Bullet.ShootBullet(bullets, direction, walter2, game);                                       //Shoot bullet?
                    game.textState = Text.Instructions(game.textState, game.money);                              //Give instructions
                    game.gameState = Obstacle.HasHitGround(obstacles);                                           //Check if player has lost
                    Game.ShowMoney(game.money);                                                                  //Write out the players money
                    Shop.ToggleShop(game);                                                                       //Enter shop?
                    Game.Clock(game);                                                                            //Increase difficulty every interval
                }

                //Shop
                else if (game.gameState == 1)
                {
                    Shop.SetupShop(borderColor, game);        //Draw shop screen and buying options
                    Game.ShowMoney(game.money);
                    Shop.BuyStuff(game);                      //Buy upgrade on input and apply changes
                    Shop.ToggleShop(game);                    //Exit shop?
                }

                //Game over screen
                else if (game.gameState == 2)
                {
                    game = Text.GameOverScreen(bullets, obstacles, game);
                }
                
                Raylib.EndDrawing();
            }

        }


        //Draw/move objects and handle collisions
        static void HandleObjects(List<Bullet> bulletList, List<Obstacle> obstacleList, Game game)
        {
            //Draw/move bullets
            foreach (Bullet shot in bulletList)
                {
                    Raylib.DrawCircle((int)shot.pos.X, (int)shot.pos.Y, 15, Color.GREEN);
                    shot.pos.X += shot.xSpeed / 6;
                    shot.pos.Y -= shot.ySpeed / 6;
                }
            
            //Draw/move obstacles and check all possible collisions
            //To remove objects from these lists using loops, it is required to go through for-loops in reverse
            for (int i = obstacleList.Count - 1; i >= 0; i--)
                {
                    Obstacle enemy = obstacleList[i];
                    int sizeX = 80;
                    int sizeY = 120;
                    enemy.color = new Color(255, enemy.red, enemy.red, 255);
                    enemy.box = new Rectangle(enemy.pos.X + 20, enemy.pos.Y, sizeX, sizeY);
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

                    //Make obstacle less red by increasing green and blue. If more green/blue than 255, make it 255.
                    enemy.red += 15;
                    if (enemy.red > 255)
                    {
                        enemy.red = 255;
                    }
                    //Make obstacle bounce at borders
                    if (enemy.pos.X > 900 || enemy.pos.X < 0)
                    {
                        enemy.xSpeed = -enemy.xSpeed;
                    }
                    //Remove obstacle if its HP is 0
                    if (enemy.hp < 1)
                    {
                        obstacleList.Remove(enemy);
                        game.money += 100;
                    }
                }
        }

        //Aim with arrow keys
        static float Aim(float angle, float direcX, float direcY)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && direcX < 90)
                {
                    angle += 4;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && direcX > -90)
                {
                    angle -= 4;
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

    }
}
