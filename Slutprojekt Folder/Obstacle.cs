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
        public static int Spawn(int cool, List<Obstacle> enemys, Texture2D image, int state)
        {
            if (cool < 1 && state > 2)
            {
                Random rand = new Random();
                int x = rand.Next(0, 900);
                int xSpeed = rand.Next(-3, 4);
                enemys.Add(new Obstacle(x, 0, xSpeed, 2, 5, image));
                cool = 100;
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
                if (enemy.pos.Y > 700)
                {
                    gameover = 2;
                }
            }
            return gameover;
        }
    }
}
