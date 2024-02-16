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
        public enum menuStates { main, settings, pause, dead, none }

        Dictionary<menuStates, Menu> menus;
        Menu currentMenu;


        public MenuManager()
        {
            menus = new()
            {
                {
                    menuStates.main,
                    new Menu(new List<Button>(){
                    new Button(new Vector2(100, 200), new Vector2(300, 150), Button.buttonStates.start),
                    new Button(new Vector2(550, 200), new Vector2(300, 150), Button.buttonStates.start),
                    new Button(new Vector2(1000, 200), new Vector2(300, 150), Button.buttonStates.settings),
                    new Button(new Vector2(1450, 200), new Vector2(300, 150), Button.buttonStates.pause)
                },
                    new List<Image>()
                    {
                        new Image(new Vector2(100, 100), new Vector2(100, 100), Data.textures["titel"])
                    })
                },

                {
                    menuStates.settings,
                    new Menu(new List<Button>(){
                    new Button(new Vector2(100, 200), new Vector2(300, 150), Button.buttonStates.start),
                    new Button(new Vector2(550, 200), new Vector2(300, 150), Button.buttonStates.start)
                })
                },

                {
                    menuStates.dead,
                    new Menu(new List<Button>()
                    {
                        new Button(new Vector2(800, 600), new Vector2(300, 150), Button.buttonStates.start),
                        new Button(new Vector2(800, 800), new Vector2(300, 150), Button.buttonStates.quit)
                    })
                }
            };

            ChangeMenu(menuStates.main);
        }

        public void ChangeMenu(menuStates menu)
        {
            currentMenu = menus[menu];
            if (currentMenu == menus[menuStates.main])
            {
                SoundManager.PlaySound(Vector2.Zero, Data.soundEffects["mixkit-haunted-slow-orchestra-634"]);
            }
        }

        public Button.buttonStates? GetInteraction()
        {
            return currentMenu.UpdateButtons();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            currentMenu.Draw(_spriteBatch);
        }
    }
}
