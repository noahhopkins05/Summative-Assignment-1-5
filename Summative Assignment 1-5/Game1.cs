using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Summative_Assignment_1_5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D buttonPressed, buttonUnpressed, animationBackground, endingBackground;
        enum Screen
        {
            Intro,
            Animation,
            Outro
        }
        Screen screen;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            buttonUnpressed = Content.Load<Texture2D>("buttonunpressed");
            buttonPressed = Content.Load<Texture2D>("buttonPressed");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(buttonUnpressed, new Rectangle(0,0, _graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight), Color.White);
            }
            else if (screen == Screen.Animation)
            {

            }
            else if (screen == Screen.Outro)
            {

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}