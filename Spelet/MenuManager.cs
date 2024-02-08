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
        Dictionary<string, Menu> menus;
        public enum buttonStates { quit, start, settings }
        public enum menuStates { main, settings, pause }


        menuStates currentMenu;


        public MenuManager()
        {
            menus = new()
            {
                { "mainMenu", new Menu() }
            };

            currentMenu = menuStates.main;
        }

        public void ChangeMenu(menuStates menu)
        {
            currentMenu = menu;
        }

        public void ExecuteButton(buttonStates button)
        {
            switch (button)
            {
                case buttonStates.start:

                    break;

                case buttonStates.settings:

                    break;

                case buttonStates.quit:

                    break;
            }
        }

        public void Update(GameTime _gameTime)
        {
            switch (currentMenu)
            {
                case menuStates.main:
                    menus["mainMenu"].Update(_gameTime);
                    break;

                case menuStates.settings:

                    break;

                case menuStates.pause:

                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            switch (currentMenu)
            {
                case menuStates.main:
                    menus["mainMenu"].Draw(_spriteBatch);
                    break;

                case menuStates.settings:

                    break;

                case menuStates.pause:

                    break;
            }
        }
    }
}
