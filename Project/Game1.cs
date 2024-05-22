using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    enum Stat
    {
        SplashScreen,
        Game,
        Final,
        Pause
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Stat Stat = Stat.Game;
        KeyboardState keyboardState, oldKeyboardState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1400;
            graphics.PreferredBackBufferHeight = 960;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Background = Content.Load<Texture2D>("background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            Space.Init(spriteBatch,graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);
            Star.Texture2D = Content.Load<Texture2D>("star");
            StarShip.Texture2D = Content.Load<Texture2D>("starship");
            Fire.Texture2D = Content.Load<Texture2D>("fire");
            EnemyShip.Texture2D = Content.Load<Texture2D>("enemyship");
            // TODO: use this.Content to load your game content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (keyboardState.IsKeyDown(Keys.Space))
                        Stat = Stat.Game;
                    break;
                case Stat.Game:
                    Space.Update();
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        Stat = Stat.SplashScreen;
                    if (keyboardState.IsKeyDown(Keys.Up)) Space.StarShip.Up();
                    if (keyboardState.IsKeyDown(Keys.Down)) Space.StarShip.Down();
                    if (keyboardState.IsKeyDown(Keys.Right)) Space.StarShip.Right();
                    if (keyboardState.IsKeyDown(Keys.Left)) Space.StarShip.Left();
                    if (keyboardState.IsKeyDown(Keys.LeftControl)
                        && oldKeyboardState.IsKeyUp(Keys.LeftControl))
                        Space.ShipFire();
                    break;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Enter))
                Exit();

            // TODO: Add your update logic here
            SplashScreen.Update();
            oldKeyboardState = keyboardState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case Stat.Game:
                    Space.Draw();
                    break;

            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        
    }
}