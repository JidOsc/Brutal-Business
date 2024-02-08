using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class Button : UIElement
    {
        Color CurrentColor, StartColor = Color.Blue;
        Rectangle backgroundBox;

        public Button(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
            CurrentColor = StartColor;
            backgroundBox = new(position.ToPoint(), size.ToPoint());
        }

        public void Update(GameTime _gameTime)
        {
            if (IsInside(Data.mouse.Position.ToVector2()))
            {
                CurrentColor = Color.LightGreen;
            }
            else
            {
                CurrentColor = StartColor;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, position, backgroundBox, CurrentColor);
        }

    }
}
