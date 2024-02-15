using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
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
            soundEffects = new List<SoundEffect>();
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
            soundEffects.Add(Content.Load<SoundEffect>("mixkit-horror-ambience-2482"));
            soundEffects.Add(Content.Load<SoundEffect>("mixkit-footsteps-in-a-tunnel-loop-543"));
            soundEffects.Add(Content.Load<SoundEffect>("mixkit-angry-dragon-growl-309"));
            Data.viewport = GraphicsDevice.Viewport;
            gameManager = new GameManager(GraphicsDevice);
            soundEffects[0].Play();

            var instance = soundEffects[0].CreateInstance();
            instance.IsLooped = true;
            instance.Play();
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
            SoundEffect.MasterVolume = 1.0f;

            




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