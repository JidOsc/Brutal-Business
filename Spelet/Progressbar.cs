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
        Texture2D 
            foreground;

        Rectangle
            backgroundHitbox;

        

        float
            maxValue = 5f,
            currentValue,
            oldValue,
            slideSpeed = 0.1f,
            newValue,
            maxWidth,

            fillingOffSet = 45,
            fillingOffSetPosX = 22,
            fillingOffSetPosY = 21,

            slide;

        Color backgroundColor;

        public Progressbar(Texture2D foreground, Vector2 position, Vector2 size, float currentValue, Texture2D background, Color backgroundColor) : base(position,size)
        {
            this.foreground = foreground;
            this.background = background;

            this.backgroundColor = backgroundColor;

            maxWidth = foreground.Width;
            newValue = currentValue;
            maxValue = currentValue;
            this.currentValue = currentValue;
            this.position = position;
            backgroundHitbox = new((int)(position.X +fillingOffSetPosX), (int)(position.Y + fillingOffSetPosY), (int)(foreground.Width - fillingOffSet), (int)(foreground.Height - fillingOffSet));
            maxWidth = backgroundHitbox.Width;
        }

        public void Update(GameTime gameTime)
        {
            UpdateSlider();
        }

        void UpdateSlider()
        {

            if(currentValue != newValue)
            {
                slide += slideSpeed;

                currentValue = oldValue + (newValue - oldValue) * slide;
                backgroundHitbox.Width = (int)(currentValue /maxValue* maxWidth);
            }
            else
            {
                slide = 0;
            }
            
        }

        public void SetNewValue(float Value)
        {
            slide = 0;

            newValue = Value;
            oldValue = currentValue;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Data.textures["background"], backgroundHitbox, backgroundColor);
            spriteBatch.Draw(foreground, position, Color.White);
            

            
        }
    }
}
