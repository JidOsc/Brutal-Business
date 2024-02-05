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
    internal class HPEntity : Entity
    {
        public float
            health,
            speed;

        public void TakeDamage(float amount)
        {
            health -= amount;

            /*if(health <= 0)
            {
                Die();
            }*/
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
