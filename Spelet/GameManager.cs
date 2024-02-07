using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spelet
{
    internal class GameManager
    {
        public MapManager mapManager;

        public GameManager()
        {
            mapManager = new MapManager();
            //short[][] map = LoadMap();
        }

        public void Update(GameTime _gameTime)
        {
            mapManager.Update(_gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            mapManager.Draw(_spriteBatch);
        }

        public void SaveMap()
        {

        }

        /*public short[][] LoadMap()
        {

        }*/
    }
}
