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
        Dictionary<menuStates, Menu> menus;
        public enum buttonStates { quit, start, settings, pause }
        public enum menuStates { main, settings, pause, none }


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

        public void ExecuteButton(buttonStates button)
        {
            switch (button)
            {
                case buttonStates.start:
                    currentMenu = menus[menuStates.none];
                    break;

                case buttonStates.pause:
                    currentMenu = menus[menuStates.pause];
                    break;

                case buttonStates.settings:
                    currentMenu = menus[menuStates.settings];
                    break;

                case buttonStates.quit:
                    //Quit();
                    break;
            }
        }

        public void Update(GameTime _gameTime)
        {
            currentMenu.Update(_gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            currentMenu.Draw(_spriteBatch);
        }
    }
}
