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
            new Button(new Vector2(100, 100), new Vector2(500, 500))
        };

        public void Update(GameTime _gameTime)
        {
            foreach(Button button in buttonList)
            {
                button.Update(_gameTime);
            }
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
