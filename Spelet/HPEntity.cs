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
            health;

        public float
            maxHealth = 1.5f,
            speed = 1.9f;

        public bool moving;

        public PlatformController
            controller;

        public HPEntity(Vector2 position, float scale) : base(position, scale)
        {
            controller = new PlatformController();
            controller.Initialize(new Rectangle(position.ToPoint(), new Point(32, 32)), 5, 5, Data.tileSize);
            controller.SetCollisionMap(Data.collisionMap);
        }

        public void UpdateHitboxVelocity()
        {
            velocity = controller.CalculateVelocity(velocity, hitbox);
            position += velocity;
            hitbox.Location = position.ToPoint();
        }

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
