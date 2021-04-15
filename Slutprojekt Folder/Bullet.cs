using System;

namespace Slutprojekt
{
    public class Bullet
    {
        public float x;
        public float y;

        public float xSpeed;
        public float ySpeed;

        public Bullet(float x_, float y_, float xSpeed_, float ySpeed_)
        {
            x = x_;
            y = y_;
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
        }
    }
}
