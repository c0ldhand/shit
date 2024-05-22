using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Project
{
    internal class Star
    {
        Vector2 Pos;
        Vector2 Dir;
        Color color;

        public static Texture2D Texture2D { get; set; }

        public Star(Vector2 Pos, Vector2 Dir)
        {
            this.Pos = Pos;
            this.Dir = Dir;
        }

        public Star(Vector2 Dir)
        {
            this.Dir = Dir;
            RandomSet();
        }
        public void Update()
        {
            Pos += Dir;
            if (Pos.X < 0)
                RandomSet();
        }

        public void RandomSet()
        {
            Pos = new Vector2(Space.GetIntRnd(Space.Width, Space.Width + 300), Space.GetIntRnd(0, Space.Height));
            color = Color.FromNonPremultiplied(Space.GetIntRnd(0, 256), Space.GetIntRnd(0, 256), Space.GetIntRnd(0, 256), 255);
        }

        public void Draw()
        {
            Space.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }
}
