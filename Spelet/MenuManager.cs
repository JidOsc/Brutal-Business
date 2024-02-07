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
    internal class MenuManager
    {
        Menu Mainmenu;

        public MenuManager()
        {
            Mainmenu = new Menu();
        }

        public void Update(GameTime _gameTime)
        {
            Mainmenu.Update(_gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Mainmenu.Draw(_spriteBatch);
        }
    }
}
