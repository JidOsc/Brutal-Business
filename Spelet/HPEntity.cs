using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
