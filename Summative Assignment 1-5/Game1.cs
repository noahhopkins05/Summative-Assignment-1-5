using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Summative_Assignment_1_5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D buttonPressed, buttonUnpressed, animationBackground, endingBackground, carTexture;
        int buttonPushed = 0;
        MouseState mouseState;
        Rectangle backgroundCoords, carCoords;
        float startTime;
        Vector2 carSpeed;
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

            backgroundCoords = new Rectangle(0,0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            carCoords = new Rectangle(0, 525, 150, 75);

            carSpeed = new Vector2(1,1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            buttonUnpressed = Content.Load<Texture2D>("buttonunpressed");
            buttonPressed = Content.Load<Texture2D>("buttonPressed");
            endingBackground = Content.Load<Texture2D>("endingBackground");
            carTexture = Content.Load<Texture2D>("car");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mouseState.LeftButton == ButtonState.Pressed)
                if (backgroundCoords.Contains(mouseState.X, mouseState.Y))
                {
                    buttonPushed = 1;
                }
            if (buttonPushed == 1)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
            if (screen == Screen.Animation)
            {
                carCoords.X += (int)carSpeed.X;
                if (carCoords.X >= _graphics.PreferredBackBufferWidth / 2)
                {
                    carCoords.X += (int)carSpeed.X * 2;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(buttonUnpressed,backgroundCoords, Color.White);
                if (buttonPushed == 1)
                {
                    _spriteBatch.Draw(buttonPressed,backgroundCoords, Color.White);
                    if (startTime > 1)
                    {
                        _spriteBatch.Draw(buttonUnpressed, backgroundCoords, Color.White);
                        if (mouseState.LeftButton == ButtonState.Pressed)
                            if (backgroundCoords.Contains(mouseState.X, mouseState.Y))
                                _spriteBatch.Draw(buttonPressed, backgroundCoords, Color.White);
                    }
                    if (startTime >= 4)
                        screen = Screen.Animation;        
                }
            }
            else if (screen == Screen.Animation)
            {
                _spriteBatch.Draw(carTexture, carCoords, Color.White);
            }
            else if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(endingBackground, backgroundCoords, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}