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
       public float value;
        
        public PickupObject(Vector2 position, float scale) : base(position, scale)
        {
            value = Data.random.Next(25, 75);
            this.position = position;
            switch (Data.random.Next(0, 4))
            {
                case 0:
                    texture = Data.textures["gear"];
                    break;
                case 1:
                    texture = Data.textures["dark_catcher_egg"];
                    break;
                case 2:
                    texture = Data.textures["broken_combat_knife"];
                    break;
                case 3:
                    texture = Data.textures["mystery_bottle"];
                    break;

            }

            
            sourceRectangle = new Rectangle(new Point(0, 0), texture.Bounds.Size);
            hitbox.Size = new Point((int)(texture.Width * scale), (int)(texture.Height * scale));
        }
    }
}


