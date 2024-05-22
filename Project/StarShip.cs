using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Project
{
    internal class StarShip
    {
        Vector2 Pos;
        Color color = Color.White;

        public int Speed { get; set; } = 3;

        public static Texture2D Texture2D { get; set; }

        public StarShip(Vector2 Pos)
        {
            this.Pos = Pos;

        }

        public Vector2 GetPositionForFire => new Vector2(Pos.X + Texture2D.Width / 2, Pos.Y + Texture2D.Height / 2);
        public void Draw()
        {
            Space.SpriteBatch.Draw(Texture2D, Pos, color);
        }

        public void Up()
        {
            if (this.Pos.Y > 0)
                this.Pos.Y -= Speed;
        }

        public void Down()
        {
            if (this.Pos.Y < Space.Height - Texture2D.Height)
                this.Pos.Y += Speed;
        }

        public void Left()
        {
            if (this.Pos.X > 0)
                this.Pos.X -= Speed;
        }

        public void Right()
        {
            if (this.Pos.X < Space.Width - Texture2D.Width)
                this.Pos.X += Speed;
        }
    }
}
