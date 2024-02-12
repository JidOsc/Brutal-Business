using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Spelet
{
    internal class Enemy : HPEntity
    {
        float viewDistance = 500f;

        List<Vector2> directionalDirections = new List<Vector2>();

        Vector2 direction;
        int lastXChecked;

        Animation walkingAnimation;

        public Enemy(Vector2 position, float scale) : base(position, scale)
        {
            texture = Data.textures["enemy"];
            direction = new Vector2(1, 0);

            hitbox.Size = hitbox.Size = new Point((int)(texture.Width / 6 * scale), (int)(texture.Height * scale));

            speed = 5f;

            walkingAnimation = new Animation(0, 0.3f, 5, 64);
        }
        
        public bool IsWallThere(Map map,Player player)
        {
            Vector2 positionB;
            Vector2 positionA;
            if (player.position.X > position.X)
            {
                positionA = Data.WorldToGrid(position);
                positionB = Data.WorldToGrid(player.position);
            }
            else
            {
                positionA = Data.WorldToGrid(player.position);
                positionB = Data.WorldToGrid(position);
            }

            for (int x = (int)positionA.X; x < positionB.X; x++)
            {
                int y = (int)(positionA.Y + (positionB.Y - positionA.Y)*(x - positionA.X) / (positionB.X - positionA.X));

                if (y < map.foregroundTiles.Length && y >= 0 && x < map.foregroundTiles[0].Length && x >= 0 && map.foregroundTiles[y][x] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool SeesPlayer(Player player, Map map)
        {
            float distanceToPlayer = Vector2.Distance(player.position, position);

            if (distanceToPlayer <= viewDistance && IsWallThere(map, player))
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

        public void Patrol(Map map)
        {
            if (controller.collisions.left || controller.collisions.right || controller.collisions.above || controller.collisions.below)
            {
                direction = GetNewDirection(GetAvailableDirections(map));
            }
            velocity = direction * speed;
        }
        
        public List<Vector2> GetAvailableDirections(Map map)
        {
            List<Vector2> directionalDirections = new List<Vector2>();
            if (controller.collisions.left == false)
            {
                directionalDirections.Add(new Vector2(-1, 0));
            }
            if (controller.collisions.right == false)
            {
                directionalDirections.Add(new Vector2(1, 0));
            }
            if (controller.collisions.above == false)
            {
                directionalDirections.Add(new Vector2(0, -1));
            }
            if (controller.collisions.below == false)
            {
                directionalDirections.Add(new Vector2(0, 1));
            }
            
            return directionalDirections;
        }

        public Vector2 GetNewDirection(List<Vector2> availableDirections)
        {
            return availableDirections[Data.random.Next(0, availableDirections.Count)];
        }

        public void Update(GameTime gameTime)
        {
            UpdateHitboxVelocity();

            rotation = Data.RelationToRotation(Vector2.Zero,velocity);
            rotation *= -1;

            walkingAnimation.Update(gameTime);
            sourceRectangle = walkingAnimation.GetFrame();
        }
    }
}
