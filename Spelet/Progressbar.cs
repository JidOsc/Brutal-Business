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
            maxValue = 5f,
            currentValue,
            oldValue,
            slideSpeed = 0.1f,
            newValue,
            slide;

        

        public Progressbar(Texture2D foreground, Vector2 position, Vector2 size, float currentvalue, Texture2D background) : base(position,size)
        {
            this.foreground = foreground;
            this.background = background;

            this.currentValue = currentvalue;
            this.position = position;
            foregroundHitbox = new(0, 0, foreground.Width, foreground.Height);

        }

        public void Update(GameTime gameTime)
        {
            if (Data.keyboard.IsKeyDown(Keys.LeftShift) && currentValue>0)
            {
                SlideValue(currentValue - 0.2f);
            }
            else
            {
                if (currentValue < maxValue)
                {
                    SlideValue(currentValue + 0.2f);
                }
            }
            UpdateSlider();
        }

        void UpdateSlider()
        {
            if(currentValue != newValue)
            {
                slide += slideSpeed;

                currentValue = oldValue + (newValue - oldValue) * slide;
                foregroundHitbox.Width = (int)(currentValue * foreground.Width);
            }
            else
            {
                slide = 0;
            }
            
        }

        public void SlideValue(float Value)
        {
            slide = 0;

            newValue = Value;
            oldValue = currentValue;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Data.textures["background"],foregroundHitbox, Color.Green);
            spriteBatch.Draw(Data.textures["background"], foregroundHitbox, Color.Red);
            spriteBatch.Draw(foreground, position, foregroundHitbox,Color.White);
        }
    }
}
