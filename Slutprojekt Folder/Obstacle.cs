using System;
using System.Numerics;
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
        public Texture2D image = Raylib.LoadTexture("floppa.png");

        public Obstacle(float x_, float y_, float xSpeed_, float ySpeed_, int hp_)
        {
            pos = new Vector2(x_, y_);
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
            hp = hp_;
        }
    }
}
