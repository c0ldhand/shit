using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Project
{
    internal class Space
    {
        public static int Width, Height;
        public static Random rnd = new Random();
        static public SpriteBatch SpriteBatch { get; set; }
        static Star[] stars;
        public static StarShip StarShip { get; set; }
        static List<Fire> fires = new List<Fire>();
        static List<EnemyShip> enemyShips = new List<EnemyShip>();
        public static int GetIntRnd(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public static void ShipFire()
        {
            fires.Add(new Fire(StarShip.GetPositionForFire));
        }

        static public void Init(SpriteBatch spriteBatch, int Width, int Height)
        {
            Space.Width = Width;
            Space.Height = Height;
            Space.SpriteBatch = spriteBatch;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
                stars[i] = new Star(new Vector2(-rnd.Next(1, 100), 0));
            StarShip = new StarShip(new Vector2(0, Height / 2 - 20));
            for (int i = 0; i < 12; i++)
                enemyShips.Add(new EnemyShip());
        }

        public static void Draw()
        {
            foreach (Star star in stars)
                star.Draw();
            foreach (Fire fire in fires)
                fire.Draw();
            foreach (EnemyShip enemyShip in enemyShips)
                enemyShip.Draw();
            StarShip.Draw();
        }

        public static void Update()
        {
            foreach (Star star in stars)
                star.Update();
            foreach(EnemyShip enemyShip in enemyShips)
                enemyShip.Update();
            for (int i = 0; i < fires.Count; i++)
            {

                fires[i].Update();
                EnemyShip enemyShipCrash = fires[i].Crash(enemyShips);
                if (enemyShipCrash != null)
                {
                    enemyShips.Remove(enemyShipCrash);
                    fires.RemoveAt(i);
                    i--;
                    continue;
                }

                if (fires[i].Hidden)
                {
                    fires.RemoveAt(i);
                    i--;
                }
            }

            


        }

     
    }
}
