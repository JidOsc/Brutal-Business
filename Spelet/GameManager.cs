using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Spelet
{
    internal class GameManager
    {
        public MapManager mapManager;
        public MenuManager menuManager;

        public enum GameState {main, ingame};
        public GameState currentGameState = new();

        string filepathFolder;


        public GameManager()
        {
            mapManager = new MapManager();
            menuManager = new MenuManager();

            currentGameState = GameState.ingame;

            //short[][] map = LoadMap();
        }

        public void Update(GameTime _gameTime)
        {
            switch (currentGameState)
            {
                case GameState.main:
                    menuManager.Update(_gameTime);
                    break;

                case GameState.ingame:
                    mapManager.Update(_gameTime);
                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            switch (currentGameState)
            {
                case GameState.main:
                    menuManager.Draw(_spriteBatch);
                    break;

                case GameState.ingame:
                    mapManager.Draw(_spriteBatch);
                    break;
            }
        }


        public void AccessFolder()
        {
            filepathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"BrutalBusiness\");

            if (!Directory.Exists(filepathFolder))
            {
                Directory.CreateDirectory(filepathFolder);
            }
        }

        public void SaveMap()
        {

        }

        /*public short[][] LoadMap()
        {

        }*/
    }
}
