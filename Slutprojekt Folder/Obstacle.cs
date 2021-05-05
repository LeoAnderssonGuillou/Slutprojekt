using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojekt
{
    public class Obstacle
    {
        public Vector2 pos;

        public float xSpeed;
        public float ySpeed;
        public int hp;
        public Rectangle box;
        public Color color = new Color(255, 255, 255, 255);
        public int red = 255;
        public Texture2D image;

        public Obstacle(float x_, float y_, float xSpeed_, float ySpeed_, int hp_, Texture2D image_)
        {
            pos = new Vector2(x_, y_);
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
            hp = hp_;
            image = image_;
        }

        //Spawn obstacles
        public static int Spawn(int cool, List<Obstacle> enemys, Texture2D image, Game game)
        {
            if (cool < 1 && game.textState > 2)
            {
                Random rand = new Random();
                float harder = game.level / 30;
                int xStart = rand.Next(0, 900);
                float xSpeed = rand.Next(-3 - (int)harder, 4 + (int)harder);
                float ySpeed = 2 + harder;

                enemys.Add(new Obstacle(xStart, 0, xSpeed, ySpeed, 4, image));
                cool = 150 - game.level * 2;
            }
            cool--;
            return cool;
        }

        //Return true if any obstacle has hit the ground
        public static int HasHitGround(List<Obstacle> obstacleList)
        {
            int gameover = 0;
            foreach (Obstacle enemy in obstacleList)
            {
                if (enemy.pos.Y > 750)
                {
                    gameover = 2;
                }
            }
            return gameover;
        }
    }
}
