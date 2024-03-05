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
        public enum buttonStates { quit, start, settings, pause, main }
        public buttonStates buttonState;

        Color
            currentColor, 
            baseColor = Color.White;

        Rectangle 
            backgroundBox;

        public Button(Vector2 position, Vector2 size, buttonStates buttonState) : base(position, size)
        {
            currentColor = baseColor;

            backgroundBox = new(position.ToPoint(), size.ToPoint());

            switch (buttonState)
            {
                //Sätter in rätt Textures
                case buttonStates.start:
                    background = Data.textures["buttonstart"];
                    break;

                case buttonStates.settings:
                    background = Data.textures["credits_button"];
                    break;

                case buttonStates.quit:
                    background = Data.textures["endbutton"];
                    break;

                case buttonStates.pause:
                    background = Data.textures["buttonstart"]; 
                    break;

                case buttonStates.main:
                    background = Data.textures["buttonstart"]; 
                    break;
            }
            
            this.buttonState = buttonState;
        }

        //Byter färg på kanpparna
        public bool IsPressed()
        {
            if (IsInside(Data.mouse.Position.ToVector2()))
            {
                currentColor = Color.LightGray;
                return Data.mouse.LeftButton == ButtonState.Pressed;
            }
            currentColor = baseColor;
            return false;

        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, backgroundBox, currentColor);
        }
    }
}
