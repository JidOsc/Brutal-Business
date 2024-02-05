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
    internal class Enemy : HPEntity
    {
        float viewDistance = 1.1f;
        
        public bool SeesPlayer(Player player)
        {
            float distanceToPlayer = (float)Math.Sqrt(Math.Pow(player.position.X - position.X, 2) + Math.Pow(player.position.Y - position.Y, 2));

            if (distanceToPlayer <= viewDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChasePlayer(Player player)
        {
            velocity = Vector2.Normalize(position - player.position) * speed * -1;         
        }

        public void Update()
        {

        }


    }
}
