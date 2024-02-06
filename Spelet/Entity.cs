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
    internal class Entity : Hitbox
    {
        public Vector2
            velocity;

        public Texture2D
            texture;

        public float
            rotation = 0f;

        public Rectangle
            sourceRectangle;

        public bool moving;


        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                texture, 
                position, 
                sourceRectangle, 
                Color.White, 
                rotation,
                new Vector2(texture.Width / 2, texture.Height / 2), 
                1, 
                SpriteEffects.None, 
                0.5f);
        }
    }
}
