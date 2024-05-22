using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Project
{
    internal class EnemyShip
    {
        public Vector2 Pos { get; set; }
        private Vector2 dir;
        Color color;
        Point size;
        public float Scale { get; set; }

        public bool IsIntersect(Rectangle rectangle)
        {
            return rectangle.Intersects(new Rectangle((int)Pos.X, (int)Pos.Y, size.X, size.Y));
        }

        public Vector2 Dir
        {
            get
            {
                return dir;
            }

            set
            {
                dir = value;
            }
        }

        public static Texture2D Texture2D { get; set; }

        public EnemyShip()
        {
            RandomSet();
        }
        public EnemyShip(Vector2 pos, Vector2 dir, float Scale)
        {
            this.Pos = pos;
            this.dir = dir;
            this.Scale = Scale;
            size = new Point((int)(Texture2D.Width * Scale), (int)(Texture2D.Height * Scale));
        }

        public EnemyShip(Vector2 dir)
        {
            this.dir = dir;
            RandomSet();
        }

        public void Update()
        {
            Pos += dir;
            if (Pos.X < 0)
                RandomSet();
        }

        public void RandomSet()
        {
            Pos = new Vector2(Space.GetIntRnd(Space.Width, Space.Width + 300),
                Space.GetIntRnd(0, Space.Height));
            Dir = new Vector2(-Space.GetIntRnd(1, 4), 0);
            Scale = (float)Space.GetIntRnd(31, 101) / 100;
            color = Color.White;
        }

        public void Draw()
        {
            Space.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }
}
