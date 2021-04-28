using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

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

        //Create new bullet and draw character shooting (if space is pressed)
        public static int ShootBullet(List<Bullet> bulletList, Vector2 direc, Texture2D character, int cool, int reload)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    Raylib.DrawTexture(character, 455, 690, Color.WHITE);
                    if (cool < 1)
                    {
                        int aimX = (int)(500 + direc.X);
                        int aimY = (int)(750 - direc.Y);
                        bulletList.Add(new Bullet(aimX, aimY, direc.X, direc.Y));
                        cool = reload;
                    }
                }
                cool--;
                return cool;
        }
    }
}
