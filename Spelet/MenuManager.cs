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

        public Button.buttonStates? GetInteraction()
        {
            return currentMenu.UpdateButtons();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            currentMenu.Draw(_spriteBatch);
            
        }
    }
}
