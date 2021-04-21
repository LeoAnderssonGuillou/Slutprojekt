using System;
using System.Numerics;

namespace Slutprojekt
{
    public class Bullet
    {
        public Vector2 pos;

        public float xSpeed;
        public float ySpeed;

        public Bullet(float x_, float y_, float xSpeed_, float ySpeed_)
        {
            pos = new Vector2(x_, y_);
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
        }
    }
}
