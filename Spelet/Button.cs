using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class Button : UIelement
    {
        Color CurrentColor, StartColor = Color.Black;
        Rectangle backgroundBox;

        public Button(Vector2 position, Vector2 size)
        {
            this.position = position;

            backgroundBox = new(position.ToPoint(), size.ToPoint());
        }

        public void Update(GameTime _gameTime)
        {
            if (IsInside(Data.mouse.Position.ToVector2()))
            {
                CurrentColor = StartColor * 0.6f;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, new Vector2(100, 100), backgroundBox, Color.White);
            
        }
    }
}

