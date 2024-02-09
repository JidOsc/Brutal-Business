using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;

namespace Spelet
{
    internal class GameManager
    {
        public MapManager mapManager;
        public MenuManager menuManager;

        public enum GameState {main, ingame};
        public GameState currentGameState = new();

        string filepathFolder;
        string filepathMaps;


        public GameManager()
        {
            mapManager = new MapManager();
            menuManager = new MenuManager();

            AccessFolder();
            mapManager.map.InsertMap(LoadMap());

            currentGameState = GameState.ingame;
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
            filepathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Brutal Business\");

            if (!Directory.Exists(filepathFolder))
            {
                Directory.CreateDirectory(filepathFolder);
            }
        }

        public short[][] LoadMap()
        {
            filepathMaps = Path.Combine(filepathFolder, @"maps.txt");

            if (File.Exists(filepathMaps))
            {
                return JsonSerializer.Deserialize<short[][]>(File.ReadAllText(filepathMaps));
            }

            short[][] tempMap;
            tempMap = new short[34][];
            for(int i = 0; i < tempMap.Length; i++)
            {
                tempMap[i] = new short[50];
            }
            return tempMap;
        }
    }
}
