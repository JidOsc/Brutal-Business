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
            new Button(new Vector2(100, 200), new Vector2(300, 150)), 
            new Button(new Vector2(550, 200), new Vector2(300, 150)),
            new Button(new Vector2(1000, 200), new Vector2(300, 150)),
            new Button(new Vector2(1450, 200), new Vector2(300, 150))
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
