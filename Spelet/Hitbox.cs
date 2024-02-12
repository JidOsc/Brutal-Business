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
    internal class Hitbox
    {
        public Vector2
            position;

        public Rectangle
            hitbox;

        public Hitbox(Vector2 position)
        {
            this.position = position;

            hitbox = new Rectangle(position.ToPoint(), new Point(0, 0));
        }

        
        public bool IsInside(Vector2 position2)
        {
            return 
                position2.X >= hitbox.Left 
                && position2.X <= hitbox.Right
                && position2.Y >= hitbox.Top
                && position2.Y <= hitbox.Bottom;
        }

        public void DrawHitbox(SpriteBatch _spritebatch)
        { 
            _spritebatch.Draw(Data.textures["background"], hitbox, Color.Red * 0.3f) ;
        }
    }
}
