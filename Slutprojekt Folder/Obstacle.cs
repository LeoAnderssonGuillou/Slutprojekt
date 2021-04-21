using System;
using System.Numerics;

namespace Slutprojekt
{
    public class Obstacle
    {
        public Vector2 pos;

        public float xSpeed;
        public float ySpeed;

        public Obstacle(float x_, float y_, float xSpeed_, float ySpeed_)
        {
            pos = new Vector2(x_, y_);
            xSpeed = xSpeed_;
            ySpeed = ySpeed_;
        }
    }
}
