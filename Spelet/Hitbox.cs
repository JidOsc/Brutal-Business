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
            position,
            size;

        public bool IsInside(Hitbox hitbox)
        {
            Rectangle tempRectangle1 = new Rectangle(position.ToPoint(), size.ToPoint());
            Rectangle tempRectangle2 = new Rectangle(hitbox.position.ToPoint(), hitbox.size.ToPoint());

            return tempRectangle1.Intersects(tempRectangle2);
        }
        public bool IsInside(Vector2 position2)
        {
            return 
                position2.X >= position.X 
                && position2.X <= position.X + size.X
                && position2.Y >= position.Y
                && position2.Y <= position.Y + size.Y;

            
        }

        public void DrawHitbox(SpriteBatch _spritebatch)    
        {
            Rectangle hitboxdraw = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

            _spritebatch.Draw(Data.textures["background"], hitboxdraw, Color.Red) ;
        }
        
    }
}
