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

        public bool IsInside(Vector2 otherPosition)
        {
            return 
                otherPosition.X >= position.X 
                && otherPosition.X <= position.X + size.X
                && otherPosition.Y >= position.Y
                && otherPosition.Y <= position.Y + size.Y;
        }
    }
}
