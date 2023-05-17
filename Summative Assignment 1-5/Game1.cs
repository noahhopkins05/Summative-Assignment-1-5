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
        int buttonPushed = 0;
        MouseState mouseState;
        Rectangle buttonCoords;
        float startTime;
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

            buttonCoords = new Rectangle(0,0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

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
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mouseState.LeftButton == ButtonState.Pressed)
                if (buttonCoords.Contains(mouseState.X, mouseState.Y))
                {
                    buttonPushed = 1;
                }
            if (buttonPushed == 1)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
                   
                    

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(buttonUnpressed,buttonCoords, Color.White);
                if (buttonPushed == 1)
                {
                    _spriteBatch.Draw(buttonPressed,buttonCoords, Color.White);
                    if (startTime > 1)
                    {
                        _spriteBatch.Draw(buttonUnpressed, buttonCoords, Color.White);
                        if (mouseState.LeftButton == ButtonState.Pressed)
                            if (buttonCoords.Contains(mouseState.X, mouseState.Y))
                                _spriteBatch.Draw(buttonPressed, buttonCoords, Color.White);
                    }
                    if (startTime >= 4)
                        screen = Screen.Animation;        
                }
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