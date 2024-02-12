using Microsoft.Xna.Framework;
using Spelet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelet
{
    internal class PickupObject : Entity
    {
        float value;

        public PickupObject(Vector2 position, float scale) : base(position, scale)
        {
            value = Data.random.Next(25, 75);
            this.position = position;

            texture = Data.textures["gear"];
            sourceRectangle = new Rectangle(new Point(0, 0), new Point(32, 32));
            hitbox.Size = texture.Bounds.Size;
        }
    }
}


