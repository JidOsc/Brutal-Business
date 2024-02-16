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
        public UIManager uiManager;

        enum GameState {main, gamealive, gamedead};
        GameState currentGameState = GameState.main;

        string filepathFolder;
        string filepathMaps;


        public GameManager(GraphicsDevice _graphics)
        {
            AccessFolder();
            mapManager = new MapManager(LoadMap(), _graphics);

            menuManager = new MenuManager();

            uiManager = new UIManager();

            currentGameState = GameState.main;
        }

        public void Update(GameTime _gameTime)
        {
            switch (currentGameState)
            {
                case GameState.main:
                    switch (menuManager.GetInteraction())
                    {
                        case Button.buttonStates.start:
                            currentGameState = GameState.gamealive;
                            break;

                        case Button.buttonStates.pause:
                            menuManager.ChangeMenu(MenuManager.menuStates.pause);
                            break;

                        case Button.buttonStates.settings:
                            menuManager.ChangeMenu(MenuManager.menuStates.settings);
                            break;

                        case Button.buttonStates.quit:
                            
                            break;
                    }
                    break;

                case GameState.gamealive:
                    mapManager.Update(_gameTime);
                    uiManager.Update(_gameTime, mapManager.player);

                    if (mapManager.player.IsDead())
                    {
                        menuManager.ChangeMenu(MenuManager.menuStates.dead);
                        currentGameState = GameState.gamedead;
                    }
                    break;

                case GameState.gamedead:
                    switch (menuManager.GetInteraction())
                    {
                        case Button.buttonStates.start:

                            mapManager.Restart(LoadMap());

                            currentGameState = GameState.gamealive;
                            break;

                        case Button.buttonStates.main:
                            currentGameState= GameState.main;
                            break;

                        case Button.buttonStates.quit:
                            
                            break;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch, GraphicsDevice _graphics)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            switch (currentGameState)
            {
                case GameState.main:
                    menuManager.Draw(_spriteBatch);
                    break;

                case GameState.gamealive:
                    mapManager.Draw(_spriteBatch, _graphics);
                    uiManager.Draw(_spriteBatch);
                    break;

                case GameState.gamedead:
                    mapManager.Draw(_spriteBatch,_graphics);
                    uiManager.Draw(_spriteBatch);
                    menuManager.Draw(_spriteBatch);
                    break;
            }

            _spriteBatch.End();
        }


        public void AccessFolder()
        {
            filepathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Brutal Business\");

            if (!Directory.Exists(filepathFolder))
            {
                Directory.CreateDirectory(filepathFolder);
            }
        }

        public Dictionary<string, short[][]> LoadMap()
        {
            filepathMaps = Path.Combine(filepathFolder, @"maps.txt");

            if (File.Exists(filepathMaps))
            {
                return JsonSerializer.Deserialize<Dictionary<string, short[][]>>(File.ReadAllText(filepathMaps));
            }

            
            Dictionary<string, short[][]> tempMap = new();
            tempMap.Add("tilemap", new short[34][]);

            for(int i = 0; i < tempMap["tilemap"].Length; i++)
            {
                tempMap["tilemap"][i] = new short[50];
            }
            return tempMap;
        }
    }
}
