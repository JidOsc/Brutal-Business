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

        public PickupObject(Vector2 position)
        {
            value = Data.random.Next(25,75);
            this.position = position;
        }

        public bool PlayerCanPickup(Player player)
        {
            if (IsInside(player.position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


