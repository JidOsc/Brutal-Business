using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Spelet
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<SoundEffect> soundEffects;

        GameManager gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Data.LoadContent(Content);
            Data.money = Content.Load<SpriteFont>("money");

            Data.viewport = GraphicsDevice.Viewport;
            gameManager = new GameManager(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Data.keyboard = Keyboard.GetState();
            Data.mouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameManager.Update(gameTime);

            Data.lastKeyboard = Data.keyboard;
            Data.lastMouse = Data.mouse;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            gameManager.Draw(_spriteBatch, GraphicsDevice);
            _spriteBatch.End();

            base.Draw(gameTime);
        } 
    }
}