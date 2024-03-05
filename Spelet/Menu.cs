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
        List<Image> imageList;

        //Listor flr button och image
        public Menu(List<Button> buttonList, List<Image> imageList)
        {
            this.buttonList = buttonList;
            this.imageList = imageList;
        }

        public Menu(List<Button> buttonList)
        {
            this.buttonList = buttonList;
        }

        //updaterar button
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

        //ritar ut buttonimage
        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach(Button button in buttonList)
            {
                button.Draw(_spriteBatch);
            }
            if (imageList != null)
            {
                foreach (Image image in imageList)
                {
                    image.Draw(_spriteBatch);
                }
            }
        }
    }
}
