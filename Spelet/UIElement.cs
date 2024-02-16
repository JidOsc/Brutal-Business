using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class UIElement : Hitbox
    {
        public Texture2D background;
        
        public UIElement(Vector2 position, Vector2 size) : base(position)
        {
            hitbox.Size = size.ToPoint();
            background = Data.textures["background"];
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(background, hitbox, Color.White);
        }
    }
}
