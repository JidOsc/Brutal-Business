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
    internal class Progressbar:UIElement
    {
        Texture2D foreground;

        Rectangle foregroundHitbox;



        float
            maxValue,
            currentValue,
            oldValue,
            slideSpeed = 0.2f,
            newValue;

        

        public Progressbar(Texture2D foreground, Vector2 position, Vector2 size, float max, Texture2D background) : base(position,size)
        {
            this.foreground = foreground;
            this.background = background;
            maxValue = max;
            currentValue = max;
            this.position = position;
            foregroundHitbox = new(0, 0, foreground.Width, foreground.Height);

        }

        void Update(GameTime gameTime)
        {
            if (Data.keyboard.IsKeyDown(Keys.LeftShift))
            {
                SlideValue(currentValue - 0.2f);
            }
            else if(Data.keyboard.IsKeyDown(Keys.LeftShift)== false)
            {
                SlideValue(currentValue + 0.2f);
            }
            UpdateSlider();
        }

        void UpdateSlider()
        {
            if(currentValue != newValue)
            {
                currentValue = oldValue + (newValue - oldValue) * slideSpeed;
                foregroundHitbox.Width = (int)(currentValue * foreground.Width);
            }
        }

        public void SlideValue(float Value)
        {
            newValue = Value;
            oldValue = currentValue;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(foreground, position, foregroundHitbox,Color.White);
            spriteBatch.Draw(Data.textures["background"],foregroundHitbox,Color.Green);
        }

    }
}
