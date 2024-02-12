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
        public enum menuStates { main, settings, pause, none }

        Dictionary<menuStates, Menu> menus;
        Menu currentMenu;


        public MenuManager()
        {
            menus = new()
            {
                { menuStates.main, new Menu() }
            };

            ChangeMenu(menuStates.main);
        }

        public void ChangeMenu(menuStates menu)
        {
            currentMenu = menus[menu];
        }

        public void Update(GameTime _gameTime)
        {
            switch (currentMenu.UpdateButtons())
            {
                case Button.buttonStates.start:

                    break;

                case Button.buttonStates.settings:

                    break;

                case Button.buttonStates.pause:

                    break;

                case Button.buttonStates.quit:

                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            currentMenu.Draw(_spriteBatch);
        }
    }
}
