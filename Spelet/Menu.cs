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
    internal class Menu
    {
        List<Button> buttonList = new List<Button>()
        {
            new Button(new Vector2(100, 200), new Vector2(300, 150), Button.buttonStates.start), 
            new Button(new Vector2(550, 200), new Vector2(300, 150), Button.buttonStates.start),
            new Button(new Vector2(1000, 200), new Vector2(300, 150), Button.buttonStates.settings),
            new Button(new Vector2(1450, 200), new Vector2(300, 150), Button.buttonStates.pause)
        };

        public Button.buttonStates? UpdateButtons()
        {
            foreach(Button button in buttonList)
            {
                if (button.IsPressed())
                {
                    return button.buttonState;
                }
            }
            return null;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach(Button button in buttonList)
            {
                button.Draw(_spriteBatch);
            }
            
        }
    }
}
