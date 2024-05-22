using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Project
{
    internal class Fire
    {
        Vector2 Pos;
        Vector2 Dir;
        const int speed = 5;
        Color color = Color.White;
        public static Texture2D Texture2D { get; set; }

        public Fire(Vector2 Pos)
        {
            this.Pos = Pos;
            this.Dir = new Vector2(speed, 0);
        }

        public bool Hidden
        {
            get
            {
                return Pos.X > Space.Width;
            }
        }

        public void Update()
        {
            if (Pos.X <= Space.Width)
                Pos += Dir;
        }
        public void Draw()
        {
            Space.SpriteBatch.Draw(Texture2D, Pos, color);
        }

        public EnemyShip Crash(List<EnemyShip> enemyShips)
        {
            foreach (EnemyShip ship in enemyShips)
                if (ship.IsIntersect(new Rectangle((int)Pos.X+Texture2D.Width, (int)Pos.Y-Texture2D.Height, Texture2D.Width, Texture2D.Height)))
                    return ship;
            return null;
        }
    }
}
