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
            rotation = 0f,
            scale = 1f;

        public Rectangle
            sourceRectangle;

        public Entity(Vector2 position, float scale) : base(position)
        {
            this.scale = scale;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                texture, 
                position + new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2) * scale, 
                sourceRectangle, 
                Color.White, 
                rotation,
                new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), 
                scale, 
                SpriteEffects.None, 
                0.5f);

            DrawHitbox(_spriteBatch) ;
        }
    }
}
