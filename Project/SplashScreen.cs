using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    static class SplashScreen
    {
        public static Texture2D Background { get; set; }
        static int timeCounter = 3;
        static Color color;
        static Vector2 textPosition = new Vector2(100, 100);
        public static SpriteFont Font { get; set; }

        static public void Draw(SpriteBatch spriteBatch) 
        { 
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font,"Press SPACE to continue\n\n\n\n Press ENTER to quit", textPosition, color);
        }

        static public void Update()
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
            timeCounter++;
        }
    }
}
