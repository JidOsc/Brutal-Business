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
        List<Button> buttonList;
        List<Texture2D> texture2DList;
        public Menu(List<Button> buttonList, List<Texture2D> texture2DList)
        {
            this.buttonList = buttonList;
            this.texture2DList = texture2DList;
        }

        public Menu(List<Button> buttonList)
        {
            this.buttonList = buttonList;
        }


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
